using Microsoft.Build.Framework;

namespace HyundaiTracker.Web.Vehicle;

public class GetDeliveryStatusRequest
{
    public const string Route = "/Vehicle/{Vin}/DeliveryStatus";
    public static string BuildRoute(string vin) => Route.Replace("{Vin}", vin);
    
    [Required]
    public string Vin { get; set; } = default!;
}
