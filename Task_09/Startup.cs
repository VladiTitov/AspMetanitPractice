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
            AppConfiguration = config;
        }
        
        public IConfiguration AppConfiguration { get; set; }
        
        public void ConfigureServices(IServiceCollection services) { }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            #region Old Startup
            // AppConfiguration["firstname"] = "alice";
            // AppConfiguration["lastname"] = "simpson";
            #endregion
            
            app.Run(async context =>
            {
                #region Old Startup
                //await context.Response.WriteAsync(AppConfiguration["firstname"]);
                // await context.Response.WriteAsync($"{AppConfiguration["firstname"]} " +
                //                                   $"{AppConfiguration["lastname"]} - " +
                //                                   $"{AppConfiguration["age"]}");
                #endregion

                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}