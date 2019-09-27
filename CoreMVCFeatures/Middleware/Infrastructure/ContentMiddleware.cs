using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Middleware.Infrastructure
{
    public class ContentMiddleware
    {
        private readonly RequestDelegate _nextDelegate;

        public ContentMiddleware(RequestDelegate nextDelegate)
        {
            _nextDelegate = nextDelegate;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.ToString().ToLower() == "/content")
            {
                await httpContext.Response.WriteAsync("Hello from content middleware");
            }
            else
            {
                await _nextDelegate.Invoke(httpContext);
            }
        }
    }
}