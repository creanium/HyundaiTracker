using System.Text.Json.Serialization;

namespace HyundaiTracker.Infrastructure.VehicleInfo.ResponseTypes;

public class Color
{
    [JsonPropertyName("SAPExteriorColorCode")]
    public string? SapExteriorColorCode { get; set; }

    [JsonPropertyName("ExtColorLongDesc")]
    public string? ExtColorLongDesc { get; set; }

    [JsonPropertyName("SwatchImagePaths")]
    public List<SwatchImagePath> SwatchImagePaths { get; } = [];

    [JsonPropertyName("360ImagePaths")]
    public List<RotateViewImagePath> RotateViewImagePaths { get; } = [];

    [JsonPropertyName("AngleImagePaths")]
    public List<AngleImagePath> AngleImagePaths { get; } = [];

    [JsonPropertyName("SAPInteriorColorCode")]
    public List<InteriorColor> SapInteriorColorCode { get; } = [];
}