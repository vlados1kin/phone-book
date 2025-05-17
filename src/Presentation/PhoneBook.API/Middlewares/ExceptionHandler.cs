using PhoneBook.Application.Exceptions;

namespace PhoneBook.API.Middlewares;

public class ExceptionHandler : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = exception switch
            {
                NotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            await context.Response.WriteAsJsonAsync(new
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            });
        }
    }
}