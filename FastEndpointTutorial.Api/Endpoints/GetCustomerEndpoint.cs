using FastEndpoints;
using FastEndpointTutorial.Api.Contracts.Requests;
using FastEndpointTutorial.Api.Contracts.Responses;
using FastEndpointTutorial.Api.Mappings;
using FastEndpointTutorial.Api.Services;
using Microsoft.AspNetCore.Authorization;

namespace FastEndpointTutorial.Api.Endpoints;

[HttpGet("customers/{id:guid}"), AllowAnonymous]
public class GetCustomerEndpoint : Endpoint<GetCustomerRequest, CustomerResponse>
{
    private readonly ICustomerService _customerService;

    public GetCustomerEndpoint(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public override async Task HandleAsync(GetCustomerRequest req, CancellationToken ct)
    {
        var customer = await _customerService.GetAsync(req.Id);
        if (customer is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var customerResponse = customer.ToCustomerResponse();
        await SendOkAsync(customerResponse, ct);
    }
}