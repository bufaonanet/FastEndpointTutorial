﻿using FastEndpointTutorial.Api.Domain.Common;

namespace FastEndpointTutorial.Api.Domain;

public class Customer
{
    public CustomerId Id { get; set; } = CustomerId.From(Guid.NewGuid());
   
    public Username Username { get; init; } = default!;

    public FullName FullName { get; init; } = default!;

    public EmailAddress Email { get; init; } = default!;

    public DateOfBirth DateOfBirth { get; init; } = default!;
}