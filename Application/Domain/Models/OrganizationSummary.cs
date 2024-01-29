namespace Application.Domain.Models;

public class OrganizationSummary
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public int BlacklistTotal { get; set; }
    public int TotalCount { get; set; }
    public IEnumerable<User>? Users { get; set; }
}
