namespace Student_Managmet.Middleware
{
    public class RequestLogsURLMaddleware
    {

        private readonly RequestDelegate _next;
        public RequestLogsURLMaddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            
            Console.WriteLine($"Request URL: {context.Request.Path}");
            
            await _next(context);
          
        }
    }
}
