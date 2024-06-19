using System.Text.Json.Serialization;

namespace HyundaiTracker.Infrastructure.VehicleInfo.ResponseTypes;

// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class RotateViewImagePath
    {
        [JsonPropertyName("ImagePath")]
        public string? ImagePath { get; set; }

        [JsonPropertyName("PackageID")]
        public string? PackageId { get; set; }
    }
