using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Task_17
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services) { }
        
        public void ConfigureOld(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.Use(async (context, next) =>
            {
                Endpoint endpoint = context.GetEndpoint();

                if (endpoint != null)
                {
                    var routePattern = (endpoint as Microsoft.AspNetCore.Routing.RouteEndpoint)?
                        .RoutePattern?
                        .RawText;
                    
                    Debug.WriteLine($"Endpoint Name: {endpoint.DisplayName}");
                    Debug.WriteLine($"Route Pattern: {routePattern}");

                    await next();
                }
                else
                {
                    Debug.WriteLine("Endpoint: null");
                    await context.Response.WriteAsync("Endpoint is not defined");
                }
            });

            #region Simple endpoints

            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapGet("/", async context =>
            //     {
            //         await context.Response.WriteAsync("Hello World!");
            //     });
            // });

            #endregion

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/index", async context =>
                {
                    await context.Response.WriteAsync("Hello Index!");
                });
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }

        public void ConfigureOld2(IApplicationBuilder app)
        {
            var myRouterHandler = new RouteHandler(Handle);
            var routeBuilder = new RouteBuilder(app, myRouterHandler);
            routeBuilder.MapRoute("default", "{controller}/{action}");
            app.UseRouter(routeBuilder.Build());
            
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            #region Without middleware
            // var routeBuilder = new RouteBuilder(app);
            // routeBuilder.MapGet("{controller}/{action}/{id?}", async context =>
            // {
            //     context.Response.ContentType = "text/html; charset=utf-8";
            //     await context.Response.WriteAsync("Hello from MapGet!");
            // });
            //
            // routeBuilder.MapRoute("{controller}/{action}", async context =>
            // {
            //     context.Response.ContentType = "text/html; charset=utf-8";
            //     await context.Response.WriteAsync("two segment request");
            // });
            //
            // routeBuilder.MapRoute("{controller}/{action}/{id}", async context =>
            // {
            //     context.Response.ContentType = "text/html; charset=utf-8";
            //     await context.Response.WriteAsync("three segment request");
            // });
            //
            //
            //
            // app.UseRouter(routeBuilder.Build());
            //
            // app.Run(async context =>
            // {
            //     await context.Response.WriteAsync("Hello World!");
            // });
            
            #endregion
            
            var routeBuilder = new RouteBuilder(app);

            routeBuilder.MapMiddlewareGet("{controller}/{action}", app =>
            {
                app.Run(async context =>
                {
                    await context.Response.WriteAsync("Hello from MapMiddlewareGet!");
                });
            });

            app.UseRouter(routeBuilder.Build());
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello World!");
            });

        }
        
        private async Task Handle(HttpContext context) =>
            await context.Response.WriteAsync("Hello ASP.NET Core!");
    }
}