using System.Text.Json.Serialization;

namespace HyundaiTracker.Infrastructure.VehicleInfo.ResponseTypes;

public class Vehicle
{
    [JsonPropertyName("vin")]
    public string? Vin { get; set; }

    [JsonPropertyName("modelNm")]
    public string? ModelName { get; set; }

    [JsonPropertyName("modelYear")]
    public int ModelYear { get; set; }

    [JsonPropertyName("trimDesc")]
    public string? TrimDesc { get; set; }

    [JsonPropertyName("colorDesc")]
    public string? ColorDesc { get; set; }

    [JsonPropertyName("extColorDesc")]
    public string? ExtColorDesc { get; set; }

    [JsonPropertyName("intColorDesc")]
    public string? IntColorDesc { get; set; }
    
    [JsonPropertyName("inventoryStatus")]
    public string? InventoryStatus { get; set; }

    [JsonPropertyName("plannedDeliveryDate")]
    public DateTime? PlannedDeliveryDate { get; set; }
}
