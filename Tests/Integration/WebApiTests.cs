using System.Net;
using System.Net.Http.Json;
using Application.Domain.Models;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Tests.Integration;

public class WebApiTests
{
    private HttpClient _testClient;
    
    public WebApiTests()
    {
        var factory = new WebApplicationFactory<Program>();
        _testClient = factory.CreateClient();
    }

    [Fact]
    public async Task HealthCheck_Returns200()
    {
        var response = await _testClient.GetAsync("/health");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task OrganizationSummaries_GetAllSummaries_ReturnsEnumerable()
    {
        var response = await _testClient.GetAsync("/api/organization-summaries");
        var summaries = await response.Content.ReadFromJsonAsync<IEnumerable<OrganizationSummary>>();
        
        Assert.NotNull(summaries);
        Assert.NotEmpty(summaries);
        /* No further assertions on the mock data, because we can't assume that it will never change */
    }
}