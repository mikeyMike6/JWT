using jwt_token.Exceptions;

namespace jwt_token.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (UserAlreadyExistsException)
            {
                context.Response.StatusCode = StatusCodes.Status409Conflict;
            }
            catch (System.Exception)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
        }
    }
}
