using Ardalis.SharedKernel;

namespace HyundaiTracker.Core.VehicleAggregate;

public class TrackingEvent(VehicleStatus status, DateTime plannedDeliveryDate) : EntityBase
{
    public DateTimeOffset Occurred { get; private set; } = DateTimeOffset.UtcNow;
    public VehicleStatus Status { get; private set; } = status;
    public DateTime PlannedDeliveryDate { get; private set; } = plannedDeliveryDate;
}
