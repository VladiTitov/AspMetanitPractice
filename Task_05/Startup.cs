using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Task_05.Services;

namespace Task_05
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            #region Dependency in constryctor
            // services.AddTransient<IMessageSender, EmailMessageSender>();
            // services.AddTransient<MessageService>();
            #endregion

            services.AddTransient<IMessageSender, EmailMessageSender>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<MessageMiddleware>();

            //app.Run(async context =>
            //{

            #region HttpContext.RequestServices

            // var messageSender = context.RequestServices.GetService<IMessageSender>();
            // context.Response.ContentType = "text/html;charset=utf-8";
            // await context.Response.WriteAsync(messageSender.Send());

            #endregion

            #region ApplicationServices

            // var messageSender = app.ApplicationServices.GetService<IMessageSender>();
            // context.Response.ContentType = "text/html;charset=utf-8";
            // await context.Response.WriteAsync(messageSender.Send());

            #endregion

            //});
        }

        #region Dependency in constryctor
        // public void Configure(IApplicationBuilder app, MessageService messageService)
        // {
        //     app.Run(async context =>
        //     {
        //         
        //         await context.Response.WriteAsync(messageService.Send());
        //     });
        // }
        #endregion
        
    }
}