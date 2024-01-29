using System.Net.Http.Json;
using Application.Dto;
using Application.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Providers;

public class ExternalDataProvider : IExternalDataProvider
{
    private readonly HttpClient _httpClient;
    private readonly string _usersEndpoint;
    private readonly string _phonesEndpoint;
    private readonly string _organizationsEndpoint;

    public ExternalDataProvider(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        
        var endpoints = configuration.GetSection("Endpoints");
        
        _usersEndpoint = endpoints["Users"]!;
        _phonesEndpoint = endpoints["Phones"]!;
        _organizationsEndpoint = endpoints["Organizations"]!;

        if (string.IsNullOrWhiteSpace(_usersEndpoint)
            || string.IsNullOrWhiteSpace(_phonesEndpoint)
            || string.IsNullOrWhiteSpace(_organizationsEndpoint))
        {
            throw new ArgumentException("Invalid endpoints configuration");
        }
    }

    public async Task<OrganizationSummaryDto> GetExternalData()
    {
        var orgsTask = _httpClient.GetFromJsonAsync<IEnumerable<OrganizationDto>>(_organizationsEndpoint);
        var usersTask = _httpClient.GetFromJsonAsync<IEnumerable<UserDto>>(_usersEndpoint);
        var phonesTask = _httpClient.GetFromJsonAsync<IEnumerable<PhoneDto>>(_phonesEndpoint);

        await Task.WhenAll(orgsTask, usersTask, phonesTask);

        return OrganizationSummaryDto.Create(
            await orgsTask ?? Enumerable.Empty<OrganizationDto>(),
            await usersTask ?? Enumerable.Empty<UserDto>(),
            await phonesTask ?? Enumerable.Empty<PhoneDto>());
    }

}