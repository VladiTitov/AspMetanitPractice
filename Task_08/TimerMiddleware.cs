using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Task_08.Services;

namespace Task_08
{
    public class TimerMiddleware
    {
        private readonly RequestDelegate _next;
        private TimeService _timeService;

        public TimerMiddleware(RequestDelegate next, TimeService timeService) =>
            (_next, _timeService) = (next, timeService);

        public async Task Invoke(HttpContext context)
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            await context.Response.WriteAsync($"Текущее время: {_timeService?.GetTime()}");
        }
    }
}