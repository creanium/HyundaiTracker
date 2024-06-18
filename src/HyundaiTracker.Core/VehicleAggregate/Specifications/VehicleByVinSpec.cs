using Ardalis.Specification;

namespace HyundaiTracker.Core.VehicleAggregate.Specifications;

public sealed class VehicleByVinSpec : Specification<Vehicle>
{
    public VehicleByVinSpec(string vin)
    {
        Query.Where(v => v.Vin == vin);
    }
}
