using System.Net;
using System.Text.Json;

namespace WebApi.Middlewares
{
    public class ExceptionHandlingMiddleware (RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        public async Task InvokeAsync (HttpContext context)
        {
            try
            {
                await next(context); // Идем дальше по цепочке
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Произошла ошибка: {Message}", ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync (HttpContext context, Exception exception)
        {
            HttpStatusCode code = exception switch
            {
                KeyNotFoundException => HttpStatusCode.NotFound,        // 404
                ArgumentException => HttpStatusCode.BadRequest,         // 400
                _ => HttpStatusCode.InternalServerError                 // 500
            };

            string result = JsonSerializer.Serialize(new
            {
                error = exception.Message,
                detail = exception.InnerException?.Message // Чтобы видеть ошибки Postgres (типа ltree)
            });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) code;

            return context.Response.WriteAsync(result);
        }
    }
}
