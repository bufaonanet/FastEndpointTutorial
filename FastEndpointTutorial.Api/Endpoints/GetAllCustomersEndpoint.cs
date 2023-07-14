using FastEndpoints;
using FastEndpointTutorial.Api.Contracts.Responses;
using FastEndpointTutorial.Api.Mappings;
using FastEndpointTutorial.Api.Services;
using Microsoft.AspNetCore.Authorization;
namespace FastEndpointTutorial.Api.Endpoints;

[HttpGet("customers"), AllowAnonymous]
public class GetAllCustomersEndpoint : EndpointWithoutRequest<GetAllCustomersResponse>
{
    private readonly ICustomerService _customerService;

    public GetAllCustomersEndpoint(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var customers = await _customerService.GetAllAsync();
        var customersResponse = customers.ToCustomersResponse();
        await SendOkAsync(customersResponse, ct);
    }
}