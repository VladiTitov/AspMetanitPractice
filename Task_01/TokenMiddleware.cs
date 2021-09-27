using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Task_01
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;
        private string _pattern;
        
        public TokenMiddleware(RequestDelegate next, string pattern) =>
            (this._next, this._pattern) = (next, pattern);

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["token"];
            if (!token.Equals(_pattern))
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Token in invalid");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}