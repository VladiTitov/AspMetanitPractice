using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Task_02
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            #region Static files 
            // var opt = new DefaultFilesOptions();
            // opt.DefaultFileNames.Clear();
            // opt.DefaultFileNames.Add("hello.html");
            // app.UseDefaultFiles(opt);

            // app.UseStaticFiles();
            //
            // app.UseStaticFiles(new StaticFileOptions()
            // {
            //     FileProvider = new PhysicalFileProvider(
            //         Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot")),
            //     RequestPath = new PathString("/pages")
            // });
            
            
            // app.UseDirectoryBrowser(new DirectoryBrowserOptions()
            // {
            //     FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot")),
            //
            //     RequestPath = new PathString("/pages")
            // });

            //app.UseDefaultFiles();
            //app.UseDirectoryBrowser();

            // app.UseFileServer(new FileServerOptions
            // {
            //     EnableDirectoryBrowsing=true,
            //     FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot")),
            //     RequestPath = new PathString("/pages"), 
            //     EnableDefaultFiles=false
            // });
            
            #endregion

            #region Remap develop error to error message
            // env.EnvironmentName = "Production";
            //
            // if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            // else app.UseExceptionHandler("/error");
            //
            // app.Map("/error", ap => 
            //     ap.Run(async context =>
            //     {
            //         await context.Response.WriteAsync("DivideByZeroException occured!");
            //     }));
            #endregion

            //if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            //app.UseStatusCodePages("text/plain", "Error. Status code: {0}");

            //app.UseStatusCodePagesWithRedirects("/error?code={0}");
            //app.UseStatusCodePagesWithReExecute("/error", "?code");

            // app.Map("/error", ap => ap.Run(async context =>
            // {
            //     await context.Response.WriteAsync($"Err: {context.Request.Query["code"]}");
            // }));

            app.Map("/hello", ap => 
                ap.Run(async context =>
                {
                    await context.Response.WriteAsync("Hello ASP.NET Core");
                }));
            
            // app.Run(async context =>
            // {
            //     var x = 0;
            //     var y = 8/x;
            //     await context.Response.WriteAsync($"Result:{y}");
            //
            // });
        }
    }
}