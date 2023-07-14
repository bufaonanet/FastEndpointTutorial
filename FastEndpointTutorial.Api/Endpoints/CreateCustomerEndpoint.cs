using FastEndpoints;
using FastEndpointTutorial.Api.Contracts.Requests;
using FastEndpointTutorial.Api.Contracts.Responses;
using FastEndpointTutorial.Api.Mappings;
using FastEndpointTutorial.Api.Services;
using Microsoft.AspNetCore.Authorization;

namespace FastEndpointTutorial.Api.Endpoints;

[HttpPost("customers"), AllowAnonymous]
public class CreateCustomerEndpoint : Endpoint<CreateCustomerRequest, CustomerResponse>
{
    private readonly ICustomerService _customerService;

    public CreateCustomerEndpoint(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public override async Task HandleAsync(CreateCustomerRequest req, CancellationToken ct)
    {
        var customer = req.ToCustomer();

        await _customerService.CreateAsync(customer);

        var customerResponse = customer.ToCustomerResponse();

        await SendCreatedAtAsync<GetCustomerEndpoint>(
            new { Id = customer.Id.Value },
            customerResponse,
            generateAbsoluteUrl: true,
            cancellation: ct);
    }
}