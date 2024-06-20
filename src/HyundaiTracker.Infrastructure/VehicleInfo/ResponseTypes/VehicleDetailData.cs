using System.Text.Json.Serialization;

namespace HyundaiTracker.Infrastructure.VehicleInfo.ResponseTypes;

public class VehicleDetailData
{
    [JsonPropertyName("vehicle")]
    public List<Vehicle>? Vehicles { get; set;  }

    [JsonPropertyName("dealer")]
    public List<Dealer>? Dealers { get; set; }
}
