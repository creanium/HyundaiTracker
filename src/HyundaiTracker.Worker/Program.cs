using System.Reflection;
using Ardalis.SharedKernel;
using HyundaiTracker.Core.ContributorAggregate;
using HyundaiTracker.Core.Interfaces;
using HyundaiTracker.Core.Services;
using HyundaiTracker.Infrastructure;
using HyundaiTracker.Infrastructure.Data;
using HyundaiTracker.Infrastructure.Email;
using HyundaiTracker.UseCases.Contributors.Create;
using HyundaiTracker.Worker;
using MediatR;
using Serilog.Extensions.Logging;
using Serilog;

var logger = Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>()
    .AddScoped<IEmailSender, MimeKitEmailSender>()
    .AddSingleton<IEntryPointService, EntryPointService>()
    .AddSingleton<IServiceLocator, ServiceScopeFactoryLocator>()
    .AddSerilog()
    .AddInfrastructureServices(builder.Configuration, new SerilogLoggerFactory(logger).CreateLogger<Program>());

ConfigureMediatR();

var host = builder.Build();

SeedDatabase(host);

host.Run();

void ConfigureMediatR()
{
    var mediatRAssemblies = new[]
    {
        Assembly.GetAssembly(typeof(Contributor)), // Core
        Assembly.GetAssembly(typeof(CreateContributorCommand)) // UseCases
    };
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(mediatRAssemblies!))
        .AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>))
        .AddScoped<IDomainEventDispatcher, MediatRDomainEventDispatcher>();
}

void SeedDatabase(IHost app)
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;

    var log = services.GetRequiredService<ILogger<Program>>();
    
    try
    {
        log.LogInformation("Seeding database...");
        var context = services.GetRequiredService<AppDbContext>();
        //          context.Database.Migrate();
        context.Database.EnsureCreated();
        SeedData.Initialize(services);
        log.LogInformation("Seeding database complete");
    }
    catch (Exception ex)
    {
        log.LogError(ex, "An error occurred seeding the DB. {ExceptionMessage}", ex.Message);
    }
}
