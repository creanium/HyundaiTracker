using System.Reflection;
using Ardalis.SharedKernel;
using HyundaiTracker.Core.ContributorAggregate;
using HyundaiTracker.Core.Interfaces;
using HyundaiTracker.Core.Services;
using HyundaiTracker.Infrastructure;
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
builder.Services.AddHostedService<Worker>();
builder.Services.AddScoped<IEmailSender, MimeKitEmailSender>();
builder.Services.AddSingleton<IEntryPointService, EntryPointService>();
builder.Services.AddSerilog();
builder.Services.AddInfrastructureServices(builder.Configuration, new SerilogLoggerFactory(logger).CreateLogger<Program>());

ConfigureMediatR();

var host = builder.Build();
host.Run();

void ConfigureMediatR()
{
    var mediatRAssemblies = new[]
    {
        Assembly.GetAssembly(typeof(Contributor)), // Core
        Assembly.GetAssembly(typeof(CreateContributorCommand)) // UseCases
    };
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(mediatRAssemblies!));
    builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
    builder.Services.AddScoped<IDomainEventDispatcher, MediatRDomainEventDispatcher>();
}
