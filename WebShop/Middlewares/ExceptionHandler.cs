using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using WebShop.Domain.Exceptions;

namespace WebApi.Middlewares
{
    public class ExceptionHandler 
        (RequestDelegate next, 
        ILogger<ExceptionHandler> logger)
        : IExceptionHandler
    {
		public async ValueTask<bool> TryHandleAsync 
            (HttpContext context,
		    Exception exception,
		    CancellationToken cancellationToken)
		{
			logger.LogError(exception, "An unhandled exception occurred: {Message}", exception.Message);
			HttpStatusCode code = exception switch
            {
                KeyNotFoundException => HttpStatusCode.NotFound,
                ArgumentException => HttpStatusCode.BadRequest,
                NotFoundException => HttpStatusCode.NotFound,
                _ => HttpStatusCode.InternalServerError
            };

            string result = JsonSerializer.Serialize(new
            {
                error = exception.Message,
                detail = exception.InnerException?.Message
            });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) code;

            await context.Response.WriteAsync(result);
            return code != HttpStatusCode.InternalServerError;
        }
    }
}
