using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Task_14
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services) { }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            #region For HttpContext.Items
            // app.Use(async (context, next) =>
            // {
            //     context.Items["text"] = "Text from HttpContext.Items";
            //     await next.Invoke();
            // });
            //
            // app.Run(async context =>
            // {
            //     context.Response.ContentType = "text/html; charset=utf-8";
            //     if (context.Items.ContainsKey("text"))
            //         await context.Response.WriteAsync($"Текст: {context.Items["text"]}");
            //     else
            //         await context.Response.WriteAsync("Случайный текст!");
            // });
            #endregion
            
            app.Run(async context =>
            {
                string login;

                if (context.Request.Cookies.TryGetValue("name", out login))
                {
                    await context.Response.WriteAsync($"Hello {login}");
                }
                else
                {
                    context.Response.Cookies.Append("name", "Tom");
                    await context.Response.WriteAsync($"Hello World!");
                }

                #region old code
                // if (context.Request.Cookies.ContainsKey("name"))
                // {
                //     string name = context.Request.Cookies["name"];
                //     await context.Response.WriteAsync($"Hello {name}");
                // }
                // else
                // {
                //     context.Response.Cookies.Append("name", "Tom");
                //     await context.Response.WriteAsync("Hello World!");
                // }

                #endregion
                
            });
        }
    }
}