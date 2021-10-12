using System;
using System.Collections.Generic;
using System.Linq;
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
        public void ConfigureServices(IServiceCollection services) { }
        
        public void Configure(IApplicationBuilder app)
        {
            var myRouteHandler = new RouteHandler(async context =>
            {
                await context.Response.WriteAsync("Routing content");
            });
            
            var routeBuilder = new RouteBuilder(app, myRouteHandler);
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
            
            routeBuilder.MapRoute("default", "{controller:length(4)}/{action:alpha}/{id:range(4,100)}");

            app.UseRouter(routeBuilder.Build());
            
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Standart context");
            });
        }
    }
}