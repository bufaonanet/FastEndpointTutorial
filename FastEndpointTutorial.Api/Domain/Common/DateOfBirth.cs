﻿using FluentValidation;
using FluentValidation.Results;
using ValueOf;

namespace FastEndpointTutorial.Api.Domain.Common;

public class DateOfBirth : ValueOf<DateOnly, DateOfBirth>
{
    protected override void Validate()
    {
        if (Value < DateOnly.FromDateTime(DateTime.Now)) 
            return;
        
        const string message = "Your date of birth cannot be in the future";
        throw new ValidationException(message, new[]
        {
            new ValidationFailure(nameof(DateOfBirth), message)
        });
    }
}