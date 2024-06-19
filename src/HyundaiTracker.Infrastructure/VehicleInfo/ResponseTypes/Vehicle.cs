using System.Text.Json.Serialization;

namespace HyundaiTracker.Infrastructure.VehicleInfo.ResponseTypes;

public class Vehicle
{
    [JsonPropertyName("vin")]
    public string? Vin { get; set; }

    [JsonPropertyName("MAPPrice")]
    public double MapPrice { get; set; }

    [JsonPropertyName("DI")]
    public Di? Di { get; set; }

    [JsonPropertyName("modelNm")]
    public string? ModelName { get; set; }

    [JsonPropertyName("modelYear")]
    public int ModelYear { get; set; }

    [JsonPropertyName("modelGroupCd")]
    public string? ModelGroupCd { get; set; }

    [JsonPropertyName("modelCd")]
    public string? ModelCd { get; set; }

    [JsonPropertyName("rbcSavings")]
    public int RbcSavings { get; set; }

    [JsonPropertyName("freight")]
    public double Freight { get; set; }

    [JsonPropertyName("msrp")]
    public int Msrp { get; set; }

    [JsonPropertyName("dealerCd")]
    public string? DealerCd { get; set; }

    [JsonPropertyName("trimDesc")]
    public string? TrimDesc { get; set; }

    [JsonPropertyName("colorDesc")]
    public string? ColorDesc { get; set; }

    [JsonPropertyName("extColorDesc")]
    public string? ExtColorDesc { get; set; }

    [JsonPropertyName("intColorDesc")]
    public string? IntColorDesc { get; set; }

    [JsonPropertyName("classDesc")]
    public string? ClassDesc { get; set; }

    [JsonPropertyName("epaClassDesc")]
    public string? EpaClassDesc { get; set; }

    [JsonPropertyName("cylinders")]
    public int Cylinders { get; set; }

    [JsonPropertyName("doorCd")]
    public string? DoorCd { get; set; }

    [JsonPropertyName("engineDesc")]
    public string? EngineDesc { get; set; }

    [JsonPropertyName("engineDisplacement")]
    public string? EngineDisplacement { get; set; }

    [JsonPropertyName("drivetrain")]
    public string? Drivetrain { get; set; }

    [JsonPropertyName("drivetrainDesc")]
    public string? DrivetrainDesc { get; set; }

    [JsonPropertyName("transmissionDesc")]
    public string? TransmissionDesc { get; set; }

    [JsonPropertyName("horsepower")]
    public int Horsepower { get; set; }

    [JsonPropertyName("cityMpg")]
    public int CityMpg { get; set; }

    [JsonPropertyName("epaEstAvgMpg")]
    public int EpaEstAvgMpg { get; set; }

    [JsonPropertyName("highwayMpg")]
    public int HighwayMpg { get; set; }

    [JsonPropertyName("fuelDesc")]
    public string? FuelDesc { get; set; }

    [JsonPropertyName("mileage")]
    public string? Mileage { get; set; }

    [JsonPropertyName("sortableMileage")]
    public int SortableMileage { get; set; }

    [JsonPropertyName("totalExtColorPrice")]
    public double TotalExtColorPrice { get; set; }

    [JsonPropertyName("totalIntColorPrice")]
    public double TotalIntColorPrice { get; set; }

    [JsonPropertyName("totalAccessoryPrice")]
    public string? TotalAccessoryPrice { get; set; }

    [JsonPropertyName("totalPackagePrice")]
    public string? TotalPackagePrice { get; set; }

    [JsonPropertyName("totalPackageOptionPrice")]
    public string? TotalPackageOptionPrice { get; set; }

    [JsonPropertyName("totalPackages")]
    public int TotalPackages { get; set; }

    [JsonPropertyName("totalOptions")]
    public int TotalOptions { get; set; }

    [JsonPropertyName("packages")]
    public string? Packages { get; set; }

    [JsonPropertyName("accessories")]
    public string? Accessories { get; set; }

    [JsonPropertyName("colors")]
    public List<Color> Colors { get; } = [];

    [JsonPropertyName("inventoryStatus")]
    public string? InventoryStatus { get; set; }

    [JsonPropertyName("PlannedDeliveryDate")]
    public DateTime PlannedDeliveryDate { get; set; }

    [JsonPropertyName("DDCSpecialProgam")]
    public List<DdcSpecialProgram> DdcSpecialPrograms { get; } = [];

    [JsonPropertyName("DealerPrice")]
    public string? DealerPrice { get; set; }
}
