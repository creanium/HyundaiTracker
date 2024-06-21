using Ardalis.SharedKernel;

namespace HyundaiTracker.Core.VehicleAggregate.Events;

public sealed class NewTrackingEventAddedEvent(Vehicle vehicle, TrackingEvent trackingEvent) : DomainEventBase
{
    public Vehicle Vehicle { get; } = vehicle;
    public TrackingEvent TrackingEvent { get; } = trackingEvent;
}
