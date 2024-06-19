using Ardalis.SharedKernel;
using StrictId;

namespace HyundaiTracker.Core.VehicleAggregate;

public class TrackingEvent(VehicleStatus status, DateOnly plannedDeliveryDate) : EntityBase<Id<TrackingEvent>>
{
    public DateTimeOffset Occurred { get; private set; } = DateTimeOffset.UtcNow;
    public VehicleStatus Status { get; private set; } = status;
    public DateOnly PlannedDeliveryDate { get; private set; } = plannedDeliveryDate;
}
