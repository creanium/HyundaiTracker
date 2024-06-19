using System.Net.Http.Json;
using HyundaiTracker.Core.DataObjects;
using HyundaiTracker.Core.Interfaces;
using HyundaiTracker.Core.VehicleAggregate;
using HyundaiTracker.Infrastructure.VehicleInfo.ResponseTypes;
using Microsoft.Extensions.Logging;

namespace HyundaiTracker.Infrastructure.VehicleInfo;

public class VehicleInfoService(HttpClient httpClient, ILogger<VehicleInfoService> logger) : IVehicleInfoService
{
    public async Task<VehicleDetails?> GetVehicleDetails(string vin)
    {
        logger.LogWarning("GetVehicleDetails base address: {BaseAddress}", httpClient.BaseAddress?.ToString());

        var remoteDetails = await httpClient.GetFromJsonAsync<VehicleDetailsRoot>($"inventory/vehicleDetails.vin.json?vin={vin}").ConfigureAwait(false);

        var vehicle = remoteDetails?.Data.FirstOrDefault()?.Vehicles.FirstOrDefault();
        
        if (vehicle == null)
        {
            return null;
        }

        return new VehicleDetails(vehicle.Vin!, vehicle.ModelYear.ToString(), "Hyundai", vehicle.ModelName!, DateOnly.FromDateTime(vehicle.PlannedDeliveryDate), VehicleStatus.FromValue(vehicle.InventoryStatus!));
    }
}
