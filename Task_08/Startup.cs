using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Task_08.Models;
using Task_08.Services;

namespace Task_08
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            #region Error case
            // services.AddTransient<ITimer, Timer>();
            // services.AddScoped<TimeService>();
            
            // services.AddScoped<ITimer, Timer>();
            // services.AddTransient<TimeService>();
            #endregion
            
            services.AddTransient<ITimer, Timer>();
            services.AddTransient<TimeService>();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseMiddleware<TimerMiddleware>();
        }
    }
}