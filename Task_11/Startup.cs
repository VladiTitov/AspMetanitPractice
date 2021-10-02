using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Task_11
{
    public class Startup
    {
        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory());
            builder.AddTextFile("config.txt");
            AppConfiguration = builder.Build();
        }
        
        public IConfiguration AppConfiguration { get; set; }
        
        
        public void ConfigureServices(IServiceCollection services) { }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var color = AppConfiguration["color"];
            var text = AppConfiguration["text"];
            
            app.Run(async context =>
            {
                await context.Response.WriteAsync($"<p style='color:{color};'>{text}</p>");
            });
        }
    }
}