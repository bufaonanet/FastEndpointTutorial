using FastEndpointTutorial.Api.Domain;
using FastEndpointTutorial.Api.Mappings;
using FastEndpointTutorial.Api.Repositories;
using FluentValidation;
using FluentValidation.Results;

namespace FastEndpointTutorial.Api.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<bool> CreateAsync(Customer customer)
    {
        var existingUser = await _customerRepository.GetAsync(customer.Id.Value);
        if (existingUser is not null)
        {
            var message = $"Customer with id {customer.Id} already exists";
            throw new ValidationException(message, new[]
            {
                new ValidationFailure(nameof(Customer), message)
            });
        }
    
        var customerDto = customer.ToCustomerDto();
        return await _customerRepository.CreateAsync(customerDto);
    }

    public async Task<Customer?> GetAsync(Guid id)
    {
        var customerDto = await _customerRepository.GetAsync(id);
        return customerDto?.ToCustomer();
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        var customers = await _customerRepository.GetAllAsync();
        return customers.Select(x => x.ToCustomer());
    }

    public async Task<bool> UpdateAsync(Customer customer)
    {
        var customerDto = customer.ToCustomerDto();
        return await _customerRepository.UpdateAsync(customerDto);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _customerRepository.DeleteAsync(id);
    }
}