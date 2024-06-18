using Ardalis.Result;
using Ardalis.SharedKernel;

namespace HyundaiTracker.UseCases.Contributors.Get;

public record GetContributorQuery(int ContributorId) : IQuery<Result<ContributorDTO>>;
