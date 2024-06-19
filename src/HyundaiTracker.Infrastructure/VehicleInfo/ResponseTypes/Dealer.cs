using System.Text.Json.Serialization;

namespace HyundaiTracker.Infrastructure.VehicleInfo.ResponseTypes;

public class Dealer
{
    [JsonPropertyName("dlrInfoId")]
    public int DlrInfoId { get; set; }

    [JsonPropertyName("dealerCd")]
    public string? DealerCd { get; set; }

    [JsonPropertyName("dealerTypeCd")]
    public string? DealerTypeCd { get; set; }

    [JsonPropertyName("dealerNm")]
    public string? DealerNm { get; set; }

    [JsonPropertyName("operationDt")]
    public string? OperationDt { get; set; }

    [JsonPropertyName("region")]
    public string? Region { get; set; }

    [JsonPropertyName("salesDistrict")]
    public string? SalesDistrict { get; set; }

    [JsonPropertyName("serviceDistrict")]
    public string? ServiceDistrict { get; set; }

    [JsonPropertyName("partsDistrict")]
    public string? PartsDistrict { get; set; }

    [JsonPropertyName("principalNm")]
    public string? PrincipalNm { get; set; }

    [JsonPropertyName("billingAddress1")]
    public string? BillingAddress1 { get; set; }

    [JsonPropertyName("billingAddress2")]
    public string? BillingAddress2 { get; set; }

    [JsonPropertyName("billingCity")]
    public string? BillingCity { get; set; }

    [JsonPropertyName("billingState")]
    public string? BillingState { get; set; }

    [JsonPropertyName("billingZipCd")]
    public string? BillingZipCd { get; set; }

    [JsonPropertyName("address1")]
    public string? Address1 { get; set; }

    [JsonPropertyName("address2")]
    public string? Address2 { get; set; }

    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("zipCd")]
    public string? ZipCd { get; set; }

    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("fax")]
    public string? Fax { get; set; }

    [JsonPropertyName("aDI")]
    public string? Adi { get; set; }

    [JsonPropertyName("generalManager")]
    public string? GeneralManager { get; set; }

    [JsonPropertyName("updatedDt")]
    public DateTime UpdatedDt { get; set; }

    [JsonPropertyName("createDt")]
    public DateTime CreateDt { get; set; }

    [JsonPropertyName("dealerUrl")]
    public string? DealerUrl { get; set; }

    [JsonPropertyName("dealerEmail")]
    public string? DealerEmail { get; set; }

    [JsonPropertyName("isEquusEnabled")]
    public int IsEquusEnabled { get; set; }

    [JsonPropertyName("isCarCareExpress")]
    public int IsCarCareExpress { get; set; }

    [JsonPropertyName("isPresidentAward")]
    public int IsPresidentAward { get; set; }

    [JsonPropertyName("isLocatorActive")]
    public int IsLocatorActive { get; set; }

    [JsonPropertyName("isServiceLoanCar")]
    public int IsServiceLoanCar { get; set; }

    [JsonPropertyName("isG80Dealer")]
    public int IsG80Dealer { get; set; }

    [JsonPropertyName("isGenesisPremium")]
    public int IsGenesisPremium { get; set; }

    [JsonPropertyName("isAcceptsLeads")]
    public int IsAcceptsLeads { get; set; }

    [JsonPropertyName("isAcceptsFleet")]
    public int IsAcceptsFleet { get; set; }

    [JsonPropertyName("isAcceptsCircle")]
    public int IsAcceptsCircle { get; set; }

    [JsonPropertyName("shopperAssuranceFlag")]
    public bool ShopperAssuranceFlag { get; set; }

    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    [JsonPropertyName("tier3Vendor")]
    public string? Tier3Vendor { get; set; }

    [JsonPropertyName("dealerRating")]
    public double DealerRating { get; set; }

    [JsonPropertyName("dealerReviewCount")]
    public int DealerReviewCount { get; set; }

    [JsonPropertyName("isAutoHookTD")]
    public int IsAutoHookTd { get; set; }

    [JsonPropertyName("scheduleGConsumerUrl")]
    public string? ScheduleGConsumerUrl { get; set; }

    [JsonPropertyName("scheduleConsumerUrl")]
    public string? ScheduleConsumerUrl { get; set; }

    [JsonPropertyName("scheduleGConsumerUrlNonSSO")]
    public string? ScheduleGConsumerUrlNonSso { get; set; }

    [JsonPropertyName("scheduleConsumerUrlNonSSO")]
    public string? ScheduleConsumerUrlNonSso { get; set; }

    [JsonPropertyName("scheduleGMenuUrl")]
    public string? ScheduleGMenuUrl { get; set; }

    [JsonPropertyName("scheduleMenuUrl")]
    public string? ScheduleMenuUrl { get; set; }

    [JsonPropertyName("scheduleGMobileUrl")]
    public string? ScheduleGMobileUrl { get; set; }

    [JsonPropertyName("scheduleMobileUrl")]
    public string? ScheduleMobileUrl { get; set; }

    [JsonPropertyName("scheduleServiceVendorId")]
    public int ScheduleServiceVendorId { get; set; }

    [JsonPropertyName("vendorName")]
    public string? VendorName { get; set; }

    [JsonPropertyName("vendorId")]
    public int VendorId { get; set; }

    [JsonPropertyName("redCapUrl")]
    public Uri? RedCapUrl { get; set; }

    [JsonPropertyName("operationHours")]
    public List<OperationDetails> OperationHours { get; } = [];

    [JsonPropertyName("IsRoadsterDealer")]
    public int IsRoadsterDealer { get; set; }

    [JsonPropertyName("DRSVendorName")]
    public string? DrsVendorName { get; set; }

    [JsonPropertyName("Roadsterdpid")]
    public string? Roadsterdpid { get; set; }

    [JsonPropertyName("IsRoadsterPricelock")]
    public string? IsRoadsterPricelock { get; set; }
}
