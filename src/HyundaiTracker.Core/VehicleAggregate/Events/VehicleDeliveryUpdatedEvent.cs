using Ardalis.SharedKernel;

namespace HyundaiTracker.Core.VehicleAggregate.Events;

public sealed class VehicleDeliveryUpdatedEvent(Vehicle vehicle, VehicleStatus oldStatus, DateOnly? oldPlannedDeliveryDate, VehicleStatus newStatus, DateOnly newPlannedDeliveryDate) : DomainEventBase
{
    public Vehicle Vehicle { get; } = vehicle;
    public VehicleStatus OldStatus { get; } = oldStatus;
    public DateOnly? OldPlannedDeliveryDate { get; } = oldPlannedDeliveryDate;
    public VehicleStatus NewStatus { get; } = newStatus;
    public DateOnly NewPlannedDeliveryDate { get; } = newPlannedDeliveryDate;
}
