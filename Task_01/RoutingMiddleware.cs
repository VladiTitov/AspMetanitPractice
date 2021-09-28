using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Task_01
{
    public class RoutingMiddleware
    {
        private readonly RequestDelegate _next;

        public RoutingMiddleware(RequestDelegate next) => 
            _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            switch (context.Request.Path.Value?.ToLower())
            {
                case "/index":
                    await context.Response.WriteAsync("Home Page");
                    break;
                case "/about":
                    await context.Response.WriteAsync("About");
                    break;
                default:
                    context.Response.StatusCode = 404;
                    break;
            }
        }
    }
}