using ShoppingCart.Core.Exceptions;
using ShoppingCart.Core.Models;
using System.Text.Json;

namespace ShoppingCart.Api.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleAsync(context, ex);
        }
    }

    private static async Task HandleAsync(HttpContext context, Exception ex)
    {
        var response = new ErrorResponseModel();

        switch (ex)
        {
            case NotFoundException:
                response.StatusCode = StatusCodes.Status404NotFound;
                response.Code = "not_found";
                break;

            case ConflictException:
                response.StatusCode = StatusCodes.Status409Conflict;
                response.Code = "conflict";
                break;

            case ForbiddenException:
                response.StatusCode = StatusCodes.Status403Forbidden;
                response.Code = "forbidden";
                break;

            default:
                response.StatusCode = StatusCodes.Status500InternalServerError;
                response.Code = "internal_error";
                break;
        }

        response.Message = ex.Message;

        context.Response.StatusCode = response.StatusCode;
        context.Response.ContentType = "application/json";

        var json = JsonSerializer.Serialize(response);

        await context.Response.WriteAsync(json);
    }
}
