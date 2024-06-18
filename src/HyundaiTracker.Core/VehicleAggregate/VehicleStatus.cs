using Ardalis.SmartEnum;

namespace HyundaiTracker.Core.VehicleAggregate;

public class VehicleStatus : SmartEnum<VehicleStatus, string>
{
    public static readonly VehicleStatus Unknown = new("Not Determined", "?");
    public static readonly VehicleStatus AtSea = new("At Sea", "AA");
    public static readonly VehicleStatus InPort = new("In Port", "PA");
    public static readonly VehicleStatus TransitReady = new("Transit Ready", "TN");
    public static readonly VehicleStatus OnRail = new("In Transit (via rail)", "IR");
    public static readonly VehicleStatus OnTruck = new("In Transit (via truck)", "IT");
    public static readonly VehicleStatus DealerStock = new("Dealer Stock", "DS");

    protected VehicleStatus(string name, string value) : base(name, value) { }
}
