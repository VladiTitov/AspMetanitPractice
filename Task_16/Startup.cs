using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

namespace Task_16
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services) { }
        
        public void ConfigureOld(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddDebug();
                builder.AddConsole();
            
                builder.AddFilter("System", LogLevel.Debug)
                    .AddFilter<DebugLoggerProvider>("Microsoft", LogLevel.Trace);
            });
            
            ILogger logger = loggerFactory.CreateLogger<Startup>();


            app.Run(async context =>
            {
                logger.LogInformation($"Requested Path: {context.Request.Path}");
                await context.Response.WriteAsync("Hello World!");
            });
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));
            var logger = loggerFactory.CreateLogger("FileLogger");
            
            app.Run(async context =>
            {
                logger.LogInformation($"Processing request {context.Request.Path}");
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}