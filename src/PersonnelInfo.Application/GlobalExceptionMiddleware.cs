using Microsoft.AspNetCore.Http;
using PersonnelInfo.Shared.Exceptions.Application;
using System.Data;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text.Json;

public class GlobalExceptionMiddleware : IMiddleware
{
    //readonly RequestDelegate _next;

    //public GlobalExceptionMiddleware(RequestDelegate next) => _next = next ?? throw new ArgumentNullException(nameof(next));

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        HttpStatusCode statusCode;
        object response;

        ( statusCode,  response) = exception switch
        {
            NotFoundEntity notFoundEx => (
             HttpStatusCode.NotFound,
            new { message = notFoundEx.Message }
           ),

            InvalidOperationException invalidOpEx => (
            HttpStatusCode.BadRequest,
            new { message = invalidOpEx.Message }
            ),

            ArgumentNullException argNullEx => (
             HttpStatusCode.BadRequest,
             new { message = argNullEx.Message }
            ),

            UnauthorizedAccessException unauthEx => (
             HttpStatusCode.Unauthorized,
             new { message = unauthEx.Message }
            ),
            _ => (
            HttpStatusCode.InternalServerError,
            new { message = "An unexpected error occurred." }
            )
        };

        context.Response.StatusCode = (int)statusCode;
        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}
