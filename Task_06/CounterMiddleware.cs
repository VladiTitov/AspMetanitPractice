using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Task_06.Services;

namespace Task_06
{
    public class CounterMiddleware
    {
        private readonly RequestDelegate _next;
        private int i = 0;
        public CounterMiddleware(RequestDelegate next) => 
            _next = next;

        public async Task InvokeAsync(HttpContext context, ICounter counter, CounterService service)
        {
            i++;
            context.Response.ContentType = "text/html;charset=utf-8";
            await context.Response.WriteAsync($"Запрос {i}; Counter: {counter.Value}; Service: {service.Counter.Value}");
        }
    }
}