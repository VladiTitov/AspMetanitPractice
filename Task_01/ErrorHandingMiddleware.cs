using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Task_01
{
    public class ErrorHandingMiddleware
    {
        private RequestDelegate _next;

        public ErrorHandingMiddleware(RequestDelegate next) =>
            _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            await _next.Invoke(context);
            if (context.Response.StatusCode.Equals(403)) 
                await context.Response.WriteAsync("Access Denied");
            else if (context.Response.StatusCode.Equals(404))
                await context.Response.WriteAsync("Not Found");
        }
    }
}