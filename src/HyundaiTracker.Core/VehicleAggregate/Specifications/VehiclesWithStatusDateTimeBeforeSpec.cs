using Ardalis.Specification;

namespace HyundaiTracker.Core.VehicleAggregate.Specifications;

public class VehiclesWithStatusDateTimeBeforeSpec : Specification<Vehicle>
{
    /// <summary>
    /// Fetches the vehicles with a status last received date time that is null or before the given date time limit.
    /// </summary>
    /// <param name="maxDateTime">The date and time to use as the upper limit.</param>
    public VehiclesWithStatusDateTimeBeforeSpec(DateTimeOffset maxDateTime)
    {
        Query.Where(v => v.StatusLastReceived == null); //.OrderByDescending(v => v.StatusLastReceived);
    }
}
