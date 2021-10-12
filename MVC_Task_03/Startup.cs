using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MVC_Task_03.Models;

namespace MVC_Task_03
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<MobileContext>(options => options.UseSqlServer(connection));
            services.AddControllersWithViews();
        }
        
        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
             
            app.UseStaticFiles();
 
            app.UseRouting();
 
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}