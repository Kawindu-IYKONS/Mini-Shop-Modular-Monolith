using Microsoft.AspNetCore.Diagnostics;

namespace Mini_Shop.exceptions
{
   
        public class GlobalExceptionHandler : IExceptionHandler
        {
            public async ValueTask<bool> TryHandleAsync(
                HttpContext httpContext,
                Exception exception,
                CancellationToken cancellationToken)
            {
            
            int statusCode;
                string message;

                switch (exception)
                {
                    case DuplicateEmailException:
                        statusCode = StatusCodes.Status400BadRequest;
                        message = exception.Message;
                        break;

                    case BusinessValidationException: 
                    
                     statusCode = StatusCodes.Status400BadRequest;
                    message = exception.Message; break;

                    case NotFoundException:
                        statusCode = StatusCodes.Status404NotFound;
                        message = exception.Message;
                        break;

                    default:
                        statusCode = StatusCodes.Status500InternalServerError;
                        message = "An unexpected error occurred.";
                        break;
                }

                httpContext.Response.StatusCode = statusCode;

                await httpContext.Response.WriteAsJsonAsync(
                    new
                    {
                        statusCode,
                        message
                    },
                    cancellationToken);

                return true;
            }
        
        }
    }

