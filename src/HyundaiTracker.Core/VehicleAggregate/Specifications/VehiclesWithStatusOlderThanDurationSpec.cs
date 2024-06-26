using Ardalis.Specification;

namespace HyundaiTracker.Core.VehicleAggregate.Specifications;

public class VehiclesWithStatusOlderThanDurationSpec : Specification<Vehicle>
{
    public VehiclesWithStatusOlderThanDurationSpec(TimeSpan maxDurationSinceLastStatusReceived)
    {
        Query.Where(v => v.StatusLastReceived == null || v.StatusLastReceived.Value.Add(maxDurationSinceLastStatusReceived) < DateTimeOffset.UtcNow);
    }
}
