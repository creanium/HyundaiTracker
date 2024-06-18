using Ardalis.HttpClientTestExtensions;
using HyundaiTracker.Infrastructure.Data;
using HyundaiTracker.Web.Contributors;
using Xunit;

namespace HyundaiTracker.FunctionalTests.ApiEndpoints;

[Collection("Sequential")]
public class ContributorList(CustomWebApplicationFactory<Program> factory) : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task ReturnsTwoContributors()
    {
        var result = await _client.GetAndDeserializeAsync<ContributorListResponse>("/Contributors");

        Assert.Equal(2, result.Contributors.Count);
        Assert.Contains(result.Contributors, i => i.Name == SeedData.Kona.Model);
        Assert.Contains(result.Contributors, i => i.Name == SeedData.Ioniq5.Model);
    }
}
