using Application.Domain.Models;

namespace Application.Interfaces;

public interface IOrganizationSummaryService
{
    /**
     * <summary>Fetches data from three endpoints and transforms this data into an <c>OrganizationSummary</c> enumerable.</summary>
     * <returns>A task object representing the <c>OrganizationSummary</c> enumerable.</returns>
     */
    Task<IEnumerable<OrganizationSummary>> GetAllSummaries();
}