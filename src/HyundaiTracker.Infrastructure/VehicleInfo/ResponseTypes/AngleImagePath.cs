using System.Text.Json.Serialization;

namespace HyundaiTracker.Infrastructure.VehicleInfo.ResponseTypes;

public class AngleImagePath
{
    [JsonPropertyName("ImagePath")]
    public string? ImagePath { get; set; }

    [JsonPropertyName("PackageID")]
    public string? PackageId { get; set; }
}