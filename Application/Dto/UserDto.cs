using System.Text.Json.Serialization;

namespace Application.Dto;

public class UserDto
{
    [JsonPropertyName("id")]
    public int? Id { get; set; }

    [JsonPropertyName("organizationId")]
    public int? OrganizationId { get; set; }

    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("avatar")]
    public string? Avatar { get; set; }
}