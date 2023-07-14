using FastEndpointTutorial.Api.Contracts.Requests;
using FluentValidation;

namespace FastEndpointTutorial.Api.Validations;

public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
{
    public CreateCustomerRequestValidator()
    {
        RuleFor(x => x.FullName).NotEmpty();
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.Username).NotEmpty();
        RuleFor(x => x.DateOfBirth).NotEmpty();
    }
}