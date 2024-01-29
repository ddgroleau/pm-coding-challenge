using System.Net;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("/api/organization-summaries")]
public class OrganizationSummaryController : ControllerBase
{
    private readonly ILogger<OrganizationSummaryController> _logger;
    private readonly IOrganizationSummaryService _organizationSummary;

    public OrganizationSummaryController(ILogger<OrganizationSummaryController> logger, IOrganizationSummaryService organizationSummary)
    {
        _logger = logger;
        _organizationSummary = organizationSummary;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSummaries()
    {
        try
        {
            var summaries = await _organizationSummary.GetAllSummaries();
            return Ok(summaries);
        }
        /* In a larger application, exception handling would be performed by middleware in program.cs */
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "{Exception} thrown at {Service}.{Method}.", nameof(HttpRequestException), nameof(OrganizationSummaryController), nameof(GetAllSummaries));
            return StatusCode((int)HttpStatusCode.ServiceUnavailable, "Unable to fetch external data, service unavailable.");
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Exception} thrown at {Service}.{Method}.", e.GetType().FullName, nameof(OrganizationSummaryController), nameof(GetAllSummaries));
            return StatusCode((int)HttpStatusCode.InternalServerError, "Internal server error.");
        }
    }
}