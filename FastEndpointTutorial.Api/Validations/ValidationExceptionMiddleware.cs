using System.Net;
using FastEndpointTutorial.Api.Contracts.Responses;
using FluentValidation;

namespace FastEndpointTutorial.Api.Validations;

public class ValidationExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ValidationExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            var messages = ex.Errors.Select(x => x.ErrorMessage).ToList();
            var validationFailureResponse = new ValidationFailureResponse
            {
                Errors = messages
            };
            await context.Response.WriteAsJsonAsync(validationFailureResponse);
        }
    }
}