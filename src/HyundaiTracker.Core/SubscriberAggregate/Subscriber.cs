using System.Collections.ObjectModel;
using System.Net.Mail;
using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using HyundaiTracker.Core.VehicleAggregate;
using StrictId;

namespace HyundaiTracker.Core.SubscriberAggregate;

public class Subscriber(MailAddress emailAddress) : EntityBase<Id<Subscriber>>, IAggregateRoot
{
    public MailAddress EmailAddress { get; private set; } = Guard.Against.Null(emailAddress);
    
    private readonly List<Id<Vehicle>> _subscribedVehicles = [];
    public ReadOnlyCollection<Id<Vehicle>> SubscribedVehicles => _subscribedVehicles.AsReadOnly();
    
    public void UpdateEmailAddress(MailAddress emailAddress)
    {
        EmailAddress = Guard.Against.Null(emailAddress);
    }
    
    public void SubscribeToVehicle(Id<Vehicle> vehicleId)
    {
        if (!_subscribedVehicles.Contains(vehicleId))
        {
            _subscribedVehicles.Add(vehicleId);
        }
    }
}
