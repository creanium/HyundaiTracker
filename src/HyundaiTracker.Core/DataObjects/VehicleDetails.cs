using HyundaiTracker.Core.VehicleAggregate;

namespace HyundaiTracker.Core.DataObjects;

public class VehicleDetails(string vin, string year, string make, string model, DateOnly plannedDeliveryDate, VehicleStatus status)
{
    public string Vin { get; private set; } = vin;
    public string Year { get; private set; } = year;
    public string Make { get; private set; } = make;
    public string Model { get; private set; } = model;
    public DateOnly PlannedDeliveryDate { get; private set; } = plannedDeliveryDate;
    public VehicleStatus Status { get; private set; } = status;
}
