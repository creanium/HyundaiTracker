using Ardalis.Result;
using Ardalis.SharedKernel;
using HyundaiTracker.Core.DataObjects;
using HyundaiTracker.Core.Interfaces;

namespace HyundaiTracker.UseCases.Vehicle.GetDeliveryStatus;

public class GetVehicleDeliveryStatusHandler(IVehicleInfoService vehicleInfoService) : ICommandHandler<GetVehicleDeliveryStatusCommand, Result<VehicleDetails>>
{
    public async Task<Result<VehicleDetails>> Handle(GetVehicleDeliveryStatusCommand request, CancellationToken cancellationToken)
    {
        var details = await vehicleInfoService.GetVehicleDetails(request.vin);

        if (details is null)
        {
            return Result.NotFound();
        }

        return details;
    }
}
