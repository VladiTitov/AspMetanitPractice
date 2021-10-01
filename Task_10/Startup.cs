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

namespace Task_10
{
    public class Startup
    {
        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("conf.json")
                .AddXmlFile("config.xml")
                .AddIniFile("conf.ini");
            
            AppConfiguration = builder.Build();
        }

        private IConfiguration AppConfiguration { get; set; }

        public void ConfigureServices(IServiceCollection services) { }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var colorJson = AppConfiguration["color-json"];
            var textJson = AppConfiguration["text-json"];
            var textSecond = AppConfiguration["namespace:class:method"];
            
            var colorXml = AppConfiguration["color-xml"];
            var textXml = AppConfiguration["text-xml"];

            var colorIni = AppConfiguration["color-ini"];
            var textIni = AppConfiguration["text-ini"];
            
            app.Run(async context =>
            {
                await context.Response.WriteAsync($"<p style='color:{colorJson}'>{textJson} - {textSecond}</p>");
                await context.Response.WriteAsync($"<p style='color:{colorXml}'>{textXml}</p>");
                await context.Response.WriteAsync($"<p style='color:{colorIni}'>{textIni}</p>");
            });
        }
    }
}