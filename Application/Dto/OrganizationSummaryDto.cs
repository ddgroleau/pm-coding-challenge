namespace Application.Dto;

public class OrganizationSummaryDto
{
    public IEnumerable<OrganizationDto> Organizations { get; private set; }
    public IEnumerable<UserDto> Users { get; private set; }
    public IEnumerable<PhoneDto> Phones { get; private set; }

    private OrganizationSummaryDto()
    {
        Organizations = new List<OrganizationDto>();
        Users = new List<UserDto>();
        Phones = new List<PhoneDto>();
    }

    public static OrganizationSummaryDto Create(IEnumerable<OrganizationDto> organizations,
        IEnumerable<UserDto> users, IEnumerable<PhoneDto> phones)
    {
        return new OrganizationSummaryDto
        {
            Organizations = organizations,
            Users = users,
            Phones = phones
        };
    }
}