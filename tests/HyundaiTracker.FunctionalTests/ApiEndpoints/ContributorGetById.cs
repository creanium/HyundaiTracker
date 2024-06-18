using Ardalis.HttpClientTestExtensions;
using HyundaiTracker.Infrastructure.Data;
using HyundaiTracker.Web.Contributors;
using Xunit;

namespace HyundaiTracker.FunctionalTests.ApiEndpoints;

[Collection("Sequential")]
public class ContributorGetById(CustomWebApplicationFactory<Program> factory) : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task ReturnsSeedContributorGivenId1()
    {
        var result = await _client.GetAndDeserializeAsync<ContributorRecord>(GetContributorByIdRequest.BuildRoute(1));

        Assert.Equal(1, result.Id);
        Assert.Equal(SeedData.Kona.Model, result.Name);
    }

    [Fact]
    public async Task ReturnsNotFoundGivenId1000()
    {
        string route = GetContributorByIdRequest.BuildRoute(1000);
        _ = await _client.GetAndEnsureNotFoundAsync(route);
    }
}
