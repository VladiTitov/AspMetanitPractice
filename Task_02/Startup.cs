using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

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

            app.UseFileServer(new FileServerOptions
            {
                EnableDirectoryBrowsing=true,
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot")),
                RequestPath = new PathString("/pages"), 
                EnableDefaultFiles=false
            });
            
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello World!");

            });
        }
    }
}