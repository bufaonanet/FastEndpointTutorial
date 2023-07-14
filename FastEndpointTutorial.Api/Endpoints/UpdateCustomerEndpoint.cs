using FastEndpoints;
using FastEndpointTutorial.Api.Contracts.Requests;
using FastEndpointTutorial.Api.Contracts.Responses;
using FastEndpointTutorial.Api.Mappings;
using FastEndpointTutorial.Api.Services;
using Microsoft.AspNetCore.Authorization;

namespace FastEndpointTutorial.Api.Endpoints;

[HttpPut("customers/{id:guid}"), AllowAnonymous]
public class UpdateCustomerEndpoint  : Endpoint<UpdateCustomerRequest, CustomerResponse>
{
    private readonly ICustomerService _customerService;

    public UpdateCustomerEndpoint(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public override async Task HandleAsync(UpdateCustomerRequest req, CancellationToken ct)
    {
        var existingCustomer = await _customerService.GetAsync(req.Id);
        if (existingCustomer is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var customer = req.ToCustomer();
        await _customerService.UpdateAsync(customer);

        var customerResponse = customer.ToCustomerResponse();

        await SendOkAsync(customerResponse, ct);
    }
}