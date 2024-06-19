using System.Text.Json.Serialization;

namespace HyundaiTracker.Infrastructure.VehicleInfo.ResponseTypes;

public class OperationDetails
{
    [JsonPropertyName("operationName")]
    public string? OperationName { get; set; }

    [JsonPropertyName("operationDay")]
    public string? OperationDay { get; set; }

    [JsonPropertyName("operationHour")]
    public string? OperationHour { get; set; }
}
