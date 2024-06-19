using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using HyundaiTracker.Core.Interfaces;
using HyundaiTracker.Core.Services;
using HyundaiTracker.Infrastructure.Data;
using HyundaiTracker.Infrastructure.Data.Queries;
using HyundaiTracker.Infrastructure.Email;
using HyundaiTracker.Infrastructure.VehicleInfo;
using HyundaiTracker.UseCases.Contributors.List;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace HyundaiTracker.Infrastructure;

public static class InfrastructureServiceExtensions
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        ConfigurationManager config,
        ILogger logger)
    {
        string? connectionString = config.GetConnectionString("SqliteConnection");
        Guard.Against.Null(connectionString);
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(connectionString));
        
        services.AddHttpClient<IVehicleInfoService, VehicleInfoService>(client =>
        {
            client.BaseAddress = new Uri("https://www.hyundaiusa.com/var/hyundai/services/");
            client.DefaultRequestHeaders.Referrer = new Uri($"https://www.hyundaiusa.com/us/en/inventory-search/details?model=Ioniq%205&year=2024");
        });

        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
        services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
        services.AddScoped<IListContributorsQueryService, ListContributorsQueryService>();
        services.AddScoped<IDeleteContributorService, DeleteContributorService>();
        
        services.Configure<MailserverConfiguration>(config.GetSection("Mailserver"));
        
        logger.LogInformation("{Project} services registered", "Infrastructure");

        return services;
    }
}
