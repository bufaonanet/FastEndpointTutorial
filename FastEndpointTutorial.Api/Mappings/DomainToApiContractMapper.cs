using FastEndpointTutorial.Api.Contracts.Responses;
using FastEndpointTutorial.Api.Domain;

namespace FastEndpointTutorial.Api.Mappings;

public static class DomainToApiContractMapper
{
    public static CustomerResponse ToCustomerResponse(this Customer customer)
    {
        return new CustomerResponse
        {
            Id = customer.Id.Value,
            Email = customer.Email.Value,
            Username = customer.Username.Value,
            FullName = customer.FullName.Value,
            DateOfBirth = customer.DateOfBirth.Value.ToDateTime(TimeOnly.MinValue)
        };
    }

    public static GetAllCustomersResponse ToCustomersResponse(this IEnumerable<Customer> customers)
    {
        return new GetAllCustomersResponse
        {
            Customers = customers.Select(x => new CustomerResponse
            {
                Id = x.Id.Value,
                Email = x.Email.Value,
                Username = x.Username.Value,
                FullName = x.FullName.Value,
                DateOfBirth = x.DateOfBirth.Value.ToDateTime(TimeOnly.MinValue)
            })
        };
    }
}