using FastEndpointTutorial.Api.Contracts.Requests;
using FluentValidation;

namespace FastEndpointTutorial.Api.Validations;

public class UpdateCustomerRequestValidator : AbstractValidator<UpdateCustomerRequest>
{
    public UpdateCustomerRequestValidator()
    {
        RuleFor(x => x.FullName).NotEmpty();
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.Username).NotEmpty();
        RuleFor(x => x.DateOfBirth).NotEmpty();
    }
}