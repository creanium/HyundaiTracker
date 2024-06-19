using System.Net.Http.Json;
using HyundaiTracker.Core.DataObjects;
using HyundaiTracker.Core.Interfaces;
using HyundaiTracker.Core.VehicleAggregate;
using HyundaiTracker.Infrastructure.VehicleInfo.ResponseTypes;

namespace HyundaiTracker.Infrastructure.VehicleInfo;

public class VehicleInfoService(IHttpClientFactory httpClientFactory) : IVehicleInfoService
{
    public async Task<VehicleDetails> GetVehicleDetails(string vin)
    {
        using var client = httpClientFactory.CreateClient();

        var remoteDetails = await client.GetFromJsonAsync<VehicleDetailsRoot>($"inventory/vehicleDetails.vin.json?vin={vin}").ConfigureAwait(false);

        var vehicle = remoteDetails?.Data.FirstOrDefault()?.Vehicles.FirstOrDefault();
        
        if(vehicle == null)
        {
            throw new InvalidOperationException("Vehicle not found");
        }

        return new VehicleDetails(vehicle.Vin!, vehicle.ModelYear.ToString(), "Hyundai", vehicle.ModelName!, DateOnly.FromDateTime(vehicle.PlannedDeliveryDate), VehicleStatus.FromValue(vehicle.InventoryStatus!));
    }
}
