using System.Text.Json.Serialization;

namespace HyundaiTracker.Infrastructure.VehicleInfo.ResponseTypes;

public class Di
{
    [JsonPropertyName("DealerVDPURL")]
    public Uri? DealerVdpUrl { get; set; }
}
