namespace Tracing
{
    public class W3CTraceHeadersMiddleware
    {
        private readonly ILogger _logger;
        private readonly RequestDelegate _next;

        public W3CTraceHeadersMiddleware(RequestDelegate next, ILogger logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var state = new Dictionary<string, object>();
            state.Add("traceparent ", context.Request.Headers["traceparent"]);
            using (_logger.BeginScope(state))
            {
                await _next(context);
            }
        }
    }
}
