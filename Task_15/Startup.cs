using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Task_15
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services) { }
        
        
        public void Configure(IApplicationBuilder app, ILogger<Startup> logger)
        {
            app.Run(async context =>
            {
                //logger.LogInformation("Processing request {0}", context.Request.Path);
                //logger.LogInformation($"Processing request {context.Request.Path}");
                
                logger.LogCritical($"LogCritical {context.Request.Path}");
                logger.LogDebug($"LogDebug {context.Request.Path}");
                logger.LogError($"LogError {context.Request.Path}");
                logger.LogInformation($"LogInformation {context.Request.Path}");
                logger.LogWarning($"LogWarning {context.Request.Path}");
                
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}