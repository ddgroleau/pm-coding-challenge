using System.Text.Json.Serialization;

namespace Application.Dto;

public class PhoneDto
{
    [JsonPropertyName("id")]
    public int? Id { get; set; }

    [JsonPropertyName("userId")]
    public int? UserId { get; set; }

    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }
    
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    
    [JsonPropertyName("blacklisted")]
    public bool Blacklisted { get; set; }
}