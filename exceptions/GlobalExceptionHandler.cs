using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc; 


namespace Mini_Shop.Exceptions
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        
        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            int statusCode;
            string message;
            string title; 

            switch (exception)
            {
                case DuplicateEmailException:
                    
                    statusCode = StatusCodes.Status409Conflict;
                    message = exception.Message;
                    title = "Conflict";
                    break;

                case BusinessValidationException:
                    statusCode = StatusCodes.Status400BadRequest;
                    message = exception.Message;
                    title = "Bad Request";
                    break;

                case NotFoundException:
                    statusCode = StatusCodes.Status404NotFound;
                    message = exception.Message;
                    title = "Not Found";
                    break;

                default:
                    statusCode = StatusCodes.Status500InternalServerError;
                    message = "An unexpected error occurred.";
                    title = "Internal Server Error";

                    
                    _logger.LogError(exception, "An unexpected error occurred.");
                    break;
            }

            httpContext.Response.StatusCode = statusCode;
            httpContext.Response.ContentType = "application/problem+json";

            
            var problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = title,
                Detail = message
            };

            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}