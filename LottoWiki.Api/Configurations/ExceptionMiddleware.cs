using System.Net;
using System.Text.Json;

namespace LottoWiki.Api.Configurations
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong.");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            HttpStatusCode statusCode;
            string message;

            switch (exception)
            {
                case ApplicationException ex:
                    statusCode = HttpStatusCode.BadRequest;
                    message = ex.Message;
                    break;

                case UnauthorizedAccessException _:
                    statusCode = HttpStatusCode.Unauthorized;
                    message = "Unauthorized access.";
                    break;

                case TimeoutException _:
                    statusCode = HttpStatusCode.RequestTimeout;
                    message = "Request timed out.";
                    break;

                case NotSupportedException _:
                    statusCode = HttpStatusCode.NotImplemented;
                    message = "This feature is not supported.";
                    break;

                case ArgumentException _:
                    statusCode = HttpStatusCode.BadRequest;
                    message = "Invalid arguments provided.";
                    break;

                case FormatException _:
                    statusCode = HttpStatusCode.BadRequest;
                    message = "Invalid format.";
                    break;

                case NotImplementedException _:
                    statusCode = HttpStatusCode.NotImplemented;
                    message = "Method not implemented";
                    break;

                case InvalidOperationException _:
                    statusCode = HttpStatusCode.BadRequest;
                    message = "Invalid Operation";
                    break;

                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    message = "Internal Server Error from the custom middleware.";
                    break;
            }

            context.Response.StatusCode = (int)statusCode;

            var response = new
            {
                StatusCode = context.Response.StatusCode,
                Message = message
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}