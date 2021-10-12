using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Task_18
{
    public class AdminRoute : IRouter
    {
        public async Task RouteAsync(RouteContext context)
        {
            var url = context.HttpContext.Request.Path.Value?.TrimEnd('/');
            if (url.StartsWith("/Admin", StringComparison.OrdinalIgnoreCase))
            {
                context.Handler = async ctx =>
                {
                    ctx.Response.ContentType = "text/html;charset=utf-8";
                    await ctx.Response.WriteAsync("Привет admin!");
                };
            }

            await Task.CompletedTask;
        }

        public VirtualPathData? GetVirtualPath(VirtualPathContext context) => 
            throw new System.NotImplementedException();
    }
}