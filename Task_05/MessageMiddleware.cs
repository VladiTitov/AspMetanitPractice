using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Task_05
{
    public class MessageMiddleware
    {
        private readonly RequestDelegate _next;

        public MessageMiddleware(RequestDelegate next) => 
            this._next = next;

        public async Task InvokeAsync(HttpContext context, IMessageSender messageSender)
        {
            context.Response.ContentType = "text/html;charset=utf-8";
            await context.Response.WriteAsync(messageSender.Send());
        }
    }
}