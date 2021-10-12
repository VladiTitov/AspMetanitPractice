using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Task_18
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //services.Configure<RouteOptions>(options => options.ConstraintMap.Add("position", typeof(PositionConstraint)));
            services.AddRouting();
        }
        
        public void ConfigureOld(IApplicationBuilder app)
        {
            var myRouteHandler = new RouteHandler(async context =>
            {
                await context.Response.WriteAsync("Routing content");
            });
            
            var routeBuilder = new RouteBuilder(app, myRouteHandler);
            
            #region Old constraints 
            // routeBuilder.MapRoute(
            //     "default", 
            //     "{controller}/{action}/{id?}", 
            //     new {action = "Index"},
            //     new {controller = "^H.*", id = @"\d{2}"}
            //     );
            // routeBuilder.MapRoute(
            //     "default",
            //     "{controller}/{action}/{id?}",
            //     null,
            //     new {httpMethod = new HttpMethodRouteConstraint("POST")}
            //     );

            // routeBuilder.MapRoute(
            //     "default",
            //     "{controller}/{action}/{id?}",
            //     new { controller = "Home", action = "Index"},
            //     new
            //     {
            //         action = new CompositeRouteConstraint( new IRouteConstraint[]
            //         {
            //             new AlphaRouteConstraint(), 
            //             new MinLengthRouteConstraint(5)
            //         })
            //     }
            // );
            
            //routeBuilder.MapRoute("default", "{controller:length(4)}/{action:alpha}/{id:range(4,100)}");
            

            #endregion
            
            routeBuilder.MapRoute("default", "{controller}/{action}/{id?}",
                null,
                new
                {
                    myRouteHandler = new CustomConstraint("/Home/Index/12"), 
                    id = new PositionConstraint()
                }
            );

            app.UseRouter(routeBuilder.Build());
            
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Standart context");
            });
        }

        public void ConfigureOld2(IApplicationBuilder app)
        {
            var myRouteHandler = new RouteHandler(HandleAsync);
            
            var routeBuilder = new RouteBuilder(app, myRouteHandler);
            routeBuilder.MapRoute("default", "{controller}/{action}/{id:position?}");
            app.UseRouter(routeBuilder.Build());
            
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Standart context");
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            var routeBuilder = new RouteBuilder(app);
            routeBuilder.Routes.Add(new AdminRoute());

            routeBuilder.MapRoute("{controler}/{action}", async context =>
            {
                context.Response.ContentType = "text/html;charset=utf-8";
                await context.Response.WriteAsync("two segment request");
            });

            app.UseRouter(routeBuilder.Build());
            
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello World");
            });
        }
        
        private async Task HandleAsync(HttpContext context)
        {
            var routeValues = context.GetRouteData().Values;
            var action = routeValues["action"]?.ToString();
            var controller = routeValues["controller"]?.ToString();
            var id = routeValues["id"]?.ToString();
            await context.Response.WriteAsync($"controller: {controller} | action: {action} | id: {id}");
        }
    }
}