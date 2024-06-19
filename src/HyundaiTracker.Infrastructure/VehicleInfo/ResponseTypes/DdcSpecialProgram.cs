using System.Text.Json.Serialization;

namespace HyundaiTracker.Infrastructure.VehicleInfo.ResponseTypes;

public class DdcSpecialProgram
{
    [JsonPropertyName("DDCincentiveID")]
    public int DdcIncentiveId { get; set; }

    [JsonPropertyName("OEMIncentiveID")]
    public string? OemIncentiveId { get; set; }

    [JsonPropertyName("ConditionCategory")]
    public string? ConditionCategory { get; set; }

    [JsonPropertyName("FinanceMethod")]
    public string? FinanceMethod { get; set; }

    [JsonPropertyName("IncentiveName")]
    public string? IncentiveName { get; set; }

    [JsonPropertyName("StartDate")]
    public DateTime StartDate { get; set; }

    [JsonPropertyName("EndDate")]
    public DateTime EndDate { get; set; }
}
