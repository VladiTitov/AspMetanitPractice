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

namespace Task_09
{
    public class Startup
    {
        #region Old Startup
        
        // public Startup()
        // {
        //     var builder = new ConfigurationBuilder()
        //         .AddInMemoryCollection(new Dictionary<string, string>
        //         {
        //             {"firstname", "Tom"},
        //             {"age", "31"}
        //         });
        //     AppConfiguration = builder.Build();
        // }
        
        #endregion

        public Startup(IConfiguration config)
        {
            #region Old parameters
            // string[] args = {"name=Alice", "age=29"};
            // var builder = new ConfigurationBuilder().AddCommandLine(args);
            // AppConfiguration = builder.Build();
            #endregion

            var builder = new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string>
            {
                {"color", "red"},
                {"text", "Hello ASP.NET 5"}
            });

            AppConfiguration = builder.Build();
            //AppConfiguration = config;
        }

        private IConfiguration AppConfiguration { get; set; }
        
        public void ConfigureServices(IServiceCollection services) { }
        
        public void Configure(IApplicationBuilder app)
        {
            #region Old Startup
            // AppConfiguration["firstname"] = "alice";
            // AppConfiguration["lastname"] = "simpson";
            #endregion

            //var java_dir = AppConfiguration["PATH"] ?? "not set";

            var color = AppConfiguration["color"];
            var text = AppConfiguration["text"];
            
            app.Run(async context =>
            {
                #region Old Startup
                //await context.Response.WriteAsync(AppConfiguration["firstname"]);
                // await context.Response.WriteAsync($"{AppConfiguration["firstname"]} " +
                //                                   $"{AppConfiguration["lastname"]} - " +
                //                                   $"{AppConfiguration["age"]}");
                #endregion

                await context.Response.WriteAsync($"<p style='color:{color};'>{text}</p>");
                //await context.Response.WriteAsync($"{AppConfiguration["name"]} - {AppConfiguration["age"]}");
                //await context.Response.WriteAsync(java_dir);

            });
        }
    }
}