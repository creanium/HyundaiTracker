﻿using System.Text;
using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using HyundaiTracker.Core.VehicleAggregate.Events;
using StrictId;

namespace HyundaiTracker.Core.VehicleAggregate;

public class Vehicle : EntityBase<Id<Vehicle>>, IAggregateRoot
{
    public string Vin { get; private set; } 
    public string? Make { get; private set; }
    public string? Model { get; private set; }
    public string? Year { get; private set; }

    public Vehicle(string vin)
    {
        Guard.Against.NullOrWhiteSpace(vin);
        Guard.Against.StringTooShort(vin, 17);
        Guard.Against.StringTooLong(vin, 17);
        Guard.Against.NullOrInvalidInput(vin, nameof(vin), DaleNewman.Vin.IsValid);
        
        Vin = vin;
    }

    private readonly List<TrackingEvent> _trackingEvents = [];
    public IReadOnlyCollection<TrackingEvent> TrackingEvents => _trackingEvents.AsReadOnly();

    private TrackingEvent? LastTrackingEvent => TrackingEvents.MaxBy(x => x.Occurred);

    public VehicleStatus Status => LastTrackingEvent?.Status ?? VehicleStatus.Unknown;
    public DateOnly? PlannedDeliveryDate => LastTrackingEvent?.PlannedDeliveryDate;

    public void AddTrackingEvent(TrackingEvent trackingEvent)
    {
        Guard.Against.Null(trackingEvent);
        _trackingEvents.Add(trackingEvent);
        
        base.RegisterDomainEvent(new NewTrackingEventAddedEvent(this, trackingEvent));
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
            details.Append(Vin);
        }

        return details.ToString();
    }
}
