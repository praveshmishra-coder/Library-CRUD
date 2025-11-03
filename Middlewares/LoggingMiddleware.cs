using System.Diagnostics;

namespace Library_BasicCRUD.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            // Log request details
            _logger.LogInformation("Request: {method} {url}",
                context.Request.Method, context.Request.Path);

            await _next(context); // call the next middleware

            stopwatch.Stop();

            // Log response details
            _logger.LogInformation("Response: {statusCode} ({time} ms)",
                context.Response.StatusCode, stopwatch.ElapsedMilliseconds);
        }
    }

    // Optional extension method for cleaner registration
    public static class LoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }
    
}
}
