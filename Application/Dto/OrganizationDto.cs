using System.Text.Json.Serialization;

namespace Application.Dto;

public class OrganizationDto
{
    [JsonPropertyName("id")]
    public int? Id { get; set; }
    
    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }
    
    [JsonPropertyName("name")]
    public string? Name { get; set; }
}