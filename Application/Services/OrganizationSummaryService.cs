using Application.Domain.Models;
using Application.Dto;
using Application.Interfaces;

namespace Application.Services;

public class OrganizationSummaryService : IOrganizationSummaryService
{

    private readonly IExternalDataProvider _externalData;

    public OrganizationSummaryService(IExternalDataProvider externalData)
    {
        _externalData = externalData;
    }
    
    public async Task<IEnumerable<OrganizationSummary>> GetAllSummaries()
    {
        var data = await _externalData.GetExternalData();

        if(!(data?.Organizations?.Any() ?? false))
            return Enumerable.Empty<OrganizationSummary>();
        
        return data.Organizations.Select(org =>
        {
            var orgUsers = data.Users.Where(u => u.OrganizationId == org.Id).ToList();
            var orgUserPhones = data.Phones.Where(p => orgUsers.Select(ou => ou.Id).Contains(p.UserId)).ToList();
            
            return new OrganizationSummary
            {
                Id = org.Id,
                Name = org.Name,
                BlacklistTotal = orgUserPhones.Count(p => p.Blacklisted),
                TotalCount = orgUserPhones.Count,
                Users = orgUsers.Select(user =>
                            new User
                            {
                                Id = user.Id,
                                Name = user.Name,
                                PhoneCount = orgUserPhones.Count(p => p.UserId == user.Id)
                            })
            };
        });

    }
}