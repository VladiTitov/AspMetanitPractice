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
        public Startup(IConfiguration config)
        {
            #region Old builder
            // var builder = new ConfigurationBuilder()
            //     .AddJsonFile("conf.json")
            //     .AddXmlFile("config.xml")
            //     .AddIniFile("conf.ini");
            #endregion

            #region Combined builder

            // var builder = new ConfigurationBuilder()
            //     //.AddJsonFile("conf.json")
            //     //AddEnvironmentVariables()
            //     .AddInMemoryCollection(new Dictionary<string, string>
            //     {
            //         { "name", "Tom" },
            //         { "age", "31"}
            //     })
            //     .AddConfiguration(config);

            #endregion
           
            var builder = new ConfigurationBuilder()
                .AddJsonFile("project.json");
            
            AppConfiguration = builder.Build();
        }

        private IConfiguration AppConfiguration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddTransient<IConfiguration>(provider => AppConfiguration);
        }
        
        public void Configure(IApplicationBuilder app)
        {
            #region Old variables

            // var colorJson = AppConfiguration["color-json"];
            // var textJson = AppConfiguration["text-json"];
            // var textSecond = AppConfiguration["namespace:class:method"];
            
            // var colorXml = AppConfiguration["color-xml"];
            // var textXml = AppConfiguration["text-xml"];

            // var colorIni = AppConfiguration["color-ini"];
            // var textIni = AppConfiguration["text-ini"];

            #endregion

            #region Old app.Run
            // var color = AppConfiguration["color-json"];
            // var text = AppConfiguration["name"];
            //
            // app.Run(async context =>
            // {
            //     #region Old WriteAsync
            //     //await context.Response.WriteAsync($"<p style='color:{colorJson}'>{textJson} - {textSecond}</p>");
            //     // await context.Response.WriteAsync($"<p style='color:{colorXml}'>{textXml}</p>");
            //     // await context.Response.WriteAsync($"<p style='color:{colorIni}'>{textIni}</p>");
            //     #endregion
            //
            //     await context.Response.WriteAsync($"<p style='color:{color};'>{text}</p>");
            // });


            #endregion

            //app.UseMiddleware<ConfigMiddleware>();

            var projectJsonContext = GetSectionContent(AppConfiguration);
            
            app.Run(async context =>
            {
                await context.Response.WriteAsync($"\n{projectJsonContext}");
            });
        }
        
        private string GetSectionContent(IConfiguration configSection)
        {
            var sectionContent = "";
            foreach (var section in configSection.GetChildren())
            {
                sectionContent += "\"" + section.Key + "\":";
                if(section.Value==null)
                {
                    string subSectionContent = GetSectionContent(section);
                    sectionContent += "{\n" + subSectionContent + "},\n";
                }
                else
                {
                    sectionContent += "\"" + section.Value + "\",\n";
                }
            }
            return sectionContent;
        }
    }
}