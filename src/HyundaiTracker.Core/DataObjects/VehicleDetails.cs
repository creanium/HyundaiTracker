using System.Text;
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

        details.Append(": ").Append(Status).Append(" - ").Append(PlannedDeliveryDate.ToString("d"));
        
        return details.ToString();
    }
}
