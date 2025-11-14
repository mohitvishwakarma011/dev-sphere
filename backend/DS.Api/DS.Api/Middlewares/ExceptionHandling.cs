namespace DS.Api.Middlewares
{
    public class ExceptionHandling
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public ExceptionHandling(RequestDelegate next,ILogger<ExceptionHandling> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return;
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var response = new
            {
                message = "Something went wrong.",
                error = exception.Message,
                stackTrace = exception.StackTrace
            };

            // Convert anonymous object to JSON
            return context.Response.WriteAsJsonAsync(response);
        }
    }
}
