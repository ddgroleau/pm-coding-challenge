using Application.Dto;

namespace Application.Interfaces;

public interface IExternalDataProvider
{
    /**
     * <summary>Executes HTTP GET requests to fetch raw data from three sources.</summary>
     * <returns>A task object representing the <c>OrganizationSummaryDto</c></returns>
     */
    Task<OrganizationSummaryDto> GetExternalData();
}