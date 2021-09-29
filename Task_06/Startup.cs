using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Task_06.Services;

namespace Task_06
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            #region AddTransient()
            // services.AddTransient<ICounter, RandomCounter>();
            // services.AddTransient<CounterService>();

            #region Factory Services

            services.AddTransient<RandomCounter>();
            services.AddTransient<ICounter>(provider =>
            {
                var counter = provider.GetService<RandomCounter>();
                return counter;
            });
            services.AddTransient<CounterService>();

            #endregion

            #endregion

            #region AddScoped()

            // services.AddScoped<ICounter, RandomCounter>();
            // services.AddScoped<CounterService>();

            #endregion

            #region AddSingleton()

            // services.AddSingleton<ICounter, RandomCounter>();
            // services.AddSingleton<CounterService>();

            #endregion
        }
        
        public void Configure(IApplicationBuilder app) =>
            app.UseMiddleware<CounterMiddleware>();
    }
}