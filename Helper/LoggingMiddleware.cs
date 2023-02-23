namespace BookApi.Helper
{
    public class LoggingMiddleware
    {
        readonly RequestDelegate _requestDelegate;
        public LoggingMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _requestDelegate(httpContext);
            }
            finally
            {
                string logText = $"{httpContext.Request?.Method} {httpContext.Request?.Path.Value}=>{httpContext.Response?.StatusCode}{Environment.NewLine}";
                File.AppendAllText("log.txt", logText);
            }
        }
    }
}
