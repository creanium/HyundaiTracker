using HyundaiTracker.Core.DataObjects;

namespace HyundaiTracker.Core.Interfaces;

public interface IVehicleInfoService
{
    Task<VehicleDetails?> GetVehicleDetails(string vin);
}
