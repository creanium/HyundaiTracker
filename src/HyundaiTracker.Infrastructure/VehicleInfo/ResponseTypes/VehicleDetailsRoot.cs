using System.Text.Json.Serialization;

namespace HyundaiTracker.Infrastructure.VehicleInfo.ResponseTypes;

public class VehicleDetailsRoot
{
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("data")]
    public List<VehicleDetailData> Data { get; } = [];
}
