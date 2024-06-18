using System.Text;
using Ardalis.GuardClauses;
using Ardalis.SharedKernel;

namespace HyundaiTracker.Core.VehicleAggregate;

public class Vehicle(string vin) : EntityBase, IAggregateRoot
{
    public string Vin { get; } = Guard.Against.LengthOutOfRange(vin, 17, 17, nameof(vin));
    public string? Make { get; private set; }
    public string? Model { get; private set; }
    public string? Year { get; private set; }

    private readonly List<TrackingEvent> _trackingEvents = [];
    public IReadOnlyCollection<TrackingEvent> TrackingEvents => _trackingEvents.AsReadOnly();

    private TrackingEvent? LastTrackingEvent => TrackingEvents.MaxBy(x => x.Occurred);

    public VehicleStatus Status => LastTrackingEvent?.Status ?? VehicleStatus.Unknown;
    public DateTime? PlannedDeliveryDate => LastTrackingEvent?.PlannedDeliveryDate;

    public void AddTrackingEvent(TrackingEvent trackingEvent)
    {
        Guard.Against.Null(trackingEvent);
        _trackingEvents.Add(trackingEvent);
    }

    public void UpdateDetails(string? year, string? make, string? model)
    {
        Year = year;
        Make = make;
        Model = model;
    }

    public override string ToString()
    {
        var details = new StringBuilder();

        if (!string.IsNullOrEmpty(Year))
        {
            details.Append(Year).Append(' ');
        }

        if (!string.IsNullOrEmpty(Make))
        {
            details.Append(Make).Append(' ');
        }

        if (!string.IsNullOrEmpty(Model))
        {
            details.Append(Model).Append(' ');
        }

        if (details.Length > 0)
        {
            details.Append('(').Append(Vin).Append(')');
        }
        else
        {
            details.Append(vin);
        }

        return details.ToString();
    }
}
