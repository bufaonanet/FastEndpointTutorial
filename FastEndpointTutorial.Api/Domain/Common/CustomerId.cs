using ValueOf;

namespace FastEndpointTutorial.Api.Domain.Common;

public class CustomerId : ValueOf<Guid, CustomerId>
{
    protected override void Validate()
    {
        if (Value == Guid.Empty)
        {
            throw new ArgumentException("Customer id cannot be empty", nameof(CustomerId));
        }
    }
}