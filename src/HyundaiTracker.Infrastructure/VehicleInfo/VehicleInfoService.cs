using System.Net.Http.Json;
using System.Text.Json;
using HyundaiTracker.Core.DataObjects;
using HyundaiTracker.Core.Interfaces;
using HyundaiTracker.Core.VehicleAggregate;
using HyundaiTracker.Infrastructure.VehicleInfo.ResponseTypes;
using Microsoft.Extensions.Logging;
using Vehicle = HyundaiTracker.Infrastructure.VehicleInfo.ResponseTypes.Vehicle;

namespace HyundaiTracker.Infrastructure.VehicleInfo;

public class VehicleInfoService(HttpClient httpClient, ILogger<VehicleInfoService> logger) : IVehicleInfoService
{
    public async Task<VehicleDetails?> GetVehicleDetails(string vin)
    {
        logger.LogWarning("GetVehicleDetails base address: {BaseAddress}", httpClient.BaseAddress?.ToString());

        var remoteDetails = await httpClient.GetStringAsync($"inventory/vehicleDetails.vin.json?vin={vin}").ConfigureAwait(false);

        logger.LogDebug("Got remote response: {Response}", remoteDetails);
        
        var vehicleDetails = JsonSerializer.Deserialize<VehicleDetailsRoot>(remoteDetails);
        
        logger.LogDebug("Parsed: {VehicleDetails}", JsonSerializer.Serialize(vehicleDetails));
        var vehicle = vehicleDetails?.Data?.FirstOrDefault()?.Vehicles?.FirstOrDefault();
        
        if (vehicle == null)
        {
            return null;
        }

        return new VehicleDetails(vehicle.Vin!, vehicle.ModelYear.ToString(), "Hyundai", vehicle.ModelName!, DateOnly.FromDateTime(vehicle.PlannedDeliveryDate!.Value), VehicleStatus.FromValue(vehicle.InventoryStatus!));
    }
}
