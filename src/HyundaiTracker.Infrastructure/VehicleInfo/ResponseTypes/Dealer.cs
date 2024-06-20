using System.Text.Json.Serialization;

namespace HyundaiTracker.Infrastructure.VehicleInfo.ResponseTypes;

public class Dealer
{
    [JsonPropertyName("dlrInfoId")]
    public int? DlrInfoId { get; set; }
}
