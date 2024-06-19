using Ardalis.Result;
using Ardalis.SharedKernel;
using HyundaiTracker.Core.DataObjects;

namespace HyundaiTracker.UseCases.Vehicle.GetDeliveryStatus;

public record GetVehicleDeliveryStatusCommand(string vin) : ICommand<Result<VehicleDetails>>;
