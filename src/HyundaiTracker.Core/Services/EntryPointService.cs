using Ardalis.SharedKernel;
using HyundaiTracker.Core.Interfaces;
using HyundaiTracker.Core.VehicleAggregate;
using HyundaiTracker.Core.VehicleAggregate.Specifications;
using Microsoft.Extensions.Logging;

namespace HyundaiTracker.Core.Services;

public class EntryPointService(ILogger<EntryPointService> logger, IRepository<Vehicle> repository, IVehicleInfoService vehicleInfoService) : IEntryPointService
{
    public async Task ExecuteAsync()
    {
        logger.LogInformation("{Service} running at: {Time}", nameof(EntryPointService), DateTimeOffset.Now);
        try
        {
            var vehiclesToCheck = await repository.ListAsync(new VehiclesWithStatusOlderThanDurationSpec(TimeSpan.FromMinutes(15)));
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
                await repository.UpdateAsync(vehicle);
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error in {Service}: {Message}", nameof(EntryPointService), ex.Message);
        }
    }
}
