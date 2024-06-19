using System.Text.Json.Serialization;

namespace HyundaiTracker.Infrastructure.VehicleInfo.ResponseTypes;

public class InteriorColor
{
    [JsonPropertyName("SAPInteriorColorCode")]
    public string? SapInteriorColorCode { get; set; }

    [JsonPropertyName("SAPInteriorColorDescription")]
    public string? SapInteriorColorDescription { get; set; }

    [JsonPropertyName("ShortID")]
    public string? ShortId { get; set; }

    [JsonPropertyName("SwatchImagePaths")]
    public List<SwatchImagePath> SwatchImagePaths { get; } = [];

    [JsonPropertyName("360ImagePaths")]
    public List<RotateViewImagePath> _360ImagePaths { get; } = [];

    [JsonPropertyName("AngleImagePaths")]
    public List<AngleImagePath> AngleImagePaths { get; } = [];
}
