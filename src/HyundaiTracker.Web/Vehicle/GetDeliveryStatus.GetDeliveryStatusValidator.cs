using DaleNewman;
using FastEndpoints;
using FluentValidation;

namespace HyundaiTracker.Web.Vehicle;

public class GetDeliveryStatusValidator : Validator<GetDeliveryStatusRequest>
{
    public GetDeliveryStatusValidator()
    {
        RuleFor(x => x.Vin)
            .Length(17)
            .NotEmpty()
            .Must(Vin.IsValid);
    }
}
