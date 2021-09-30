using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Task_07.Services;

namespace Task_07
{
    public class TimerMiddleware
    {
        #region For AddTransient()
        // private readonly RequestDelegate _next;
        //
        // private readonly TimeService _timeService;
        //
        // public TimerMiddleware(RequestDelegate next, TimeService timeService) =>
        //     (_next, _timeService) = (next, timeService);
        //
        // public async Task InvokeAsync(HttpContext context)
        // {
        //     if (context.Request.Path.Value.ToLower().Equals("/time"))
        //     {
        //         context.Response.ContentType = "text/html; charset=utf-8";
        //         await context.Response.WriteAsync($"Текущее время {_timeService?.Time}");
        //     }
        //     else
        //     {
        //         await _next.Invoke(context);
        //     }
        // } 
        #endregion

        private readonly RequestDelegate _next;

        public TimerMiddleware(RequestDelegate next) => 
            _next = next;

        public async Task InvokeAsync(HttpContext context, TimeService timeService)
        {
            if (context.Request.Path.Value.ToLower().Equals("/time"))
            {
                context.Response.ContentType = "text/html; charset=utf-8";
                await context.Response.WriteAsync($"Текущее время: {timeService?.Time}");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}