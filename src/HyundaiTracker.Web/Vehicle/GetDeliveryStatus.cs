using Ardalis.Result;
using FastEndpoints;
using HyundaiTracker.Core.DataObjects;
using HyundaiTracker.UseCases.Vehicle.GetDeliveryStatus;
using MediatR;

namespace HyundaiTracker.Web.Vehicle;

public class GetDeliveryStatus(IMediator mediator, ILogger<GetDeliveryStatus> logger) : Endpoint<GetDeliveryStatusRequest, VehicleDetails>
{
    public override void Configure()
    {
        Get(GetDeliveryStatusRequest.Route);
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetDeliveryStatusRequest request, CancellationToken cancellationToken)
    {
        var command = new GetVehicleDeliveryStatusCommand(request.Vin);
        var result = await mediator.Send(command, cancellationToken);
        logger.LogInformation("Got delivery status for {Vin}: {PlannedDeliveryDate}", request.Vin, result.Value.PlannedDeliveryDate);

        if (result.Status == ResultStatus.NotFound)
        {
            await SendNotFoundAsync(cancellationToken);
            return;
        }

        Response = result.Value;
    }
}
