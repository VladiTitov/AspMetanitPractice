using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Task_04.Services;

namespace Task_04
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTimeService();
        }
        
        public void Configure(IApplicationBuilder app, TimeService timeService)
        {
            app.Run(async context =>
            {
                context.Response.ContentType = "text/html; charset=utf-8";
                await context.Response.WriteAsync($"Текущее время: {timeService?.GetTime()}");
            });
        }
    }
}