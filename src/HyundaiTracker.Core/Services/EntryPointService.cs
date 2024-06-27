using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using HyundaiTracker.Core.Interfaces;
using HyundaiTracker.Core.VehicleAggregate;
using HyundaiTracker.Core.VehicleAggregate.Specifications;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace HyundaiTracker.Core.Services;

public class EntryPointService(ILogger<EntryPointService> logger, 
    IVehicleInfoService vehicleInfoService,
    IServiceLocator serviceLocator) : IEntryPointService
{
    public async Task ExecuteAsync()
    {
        logger.LogInformation("{Service} running at: {Time}", nameof(EntryPointService), DateTimeOffset.Now);
        try
        {
            // EF Requires a scope so we are creating one per execution here
            using var scope = serviceLocator.CreateScope();
            var repository = scope.ServiceProvider
                .GetService<IRepository<Vehicle>>();

            Guard.Against.Null(repository);

            var upperStatusLimit = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromMinutes(15));
            var vehiclesToCheck = await repository.ListAsync(new VehiclesWithStatusDateTimeBeforeSpec(upperStatusLimit));
            logger.LogInformation("Got {VehicleCount} vehicles to check", vehiclesToCheck.Count);

            if (vehiclesToCheck.Count == 0)
            {
                return;
            }

            foreach (var vehicle in vehiclesToCheck)
            {
                var vehicleInfo = await vehicleInfoService.GetVehicleDetails(vehicle.Vin);
                logger.LogInformation("Got vehicle info for {Vin}: {VehicleDetails}", vehicle.Vin, vehicleInfo);

                if (vehicleInfo == null)
                {
                    logger.LogWarning("Could not get vehicle info for {Vin}", vehicle.Vin);
                    continue;
                }

                vehicle.StatusReceived();
                vehicle.UpdateDelivery(vehicleInfo.Status, vehicleInfo.PlannedDeliveryDate);

                if (vehicle.Make is null || vehicle.Year is null || vehicle.Model is null)
                {
                    vehicle.UpdateDetails(vehicleInfo.Year, vehicleInfo.Make, vehicleInfo.Model);
                }
                
                await repository.UpdateAsync(vehicle);
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error in {Service}: {Message}", nameof(EntryPointService), ex.Message);
        }
    }
}
