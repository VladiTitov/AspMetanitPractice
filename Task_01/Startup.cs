using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Task_01
{
    public class Startup
    {
        private IHostEnvironment _env;
        public Startup(IHostEnvironment env) => _env = env;

        public delegate Task RequestDelegate(HttpContext context);

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void ConfigureOld(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var x = 2;
            // если приложение в процессе разработки
            if (env.IsDevelopment())
            {
                // то выводим информацию об ошибке, при наличии ошибки
                app.UseDeveloperExceptionPage();
            }

            // добавляем возможности маршрутизации
            app.UseRouting();

            // устанавливаем адреса, которые будут обрабатываться
            app.UseEndpoints(endpoints =>
            {
                // обработка запроса - получаем констекст запроса в виде объекта context
                endpoints.MapGet("/", async context =>
                {
                    x = x * 2;
                    // отправка ответа в виде строки "Hello World! This is first ASP project."
                    await context.Response.WriteAsync($"Application name: {_env.ApplicationName}\nResult={x}");
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            #region Run

            //app.Run(async (context) => await context.Response.WriteAsync("Hello World!"));

            // var x = 5;
            // var y = 8;
            // var z = 0;
            //
            // app.Use(async (context, next) =>
            // {
            //     z = x * y;
            //     await next.Invoke();
            // });
            //
            // app.Run(async (context) => await context.Response.WriteAsync($"x * y = {z}"));


            #endregion

            #region Error code

            // Лучше так не делать, обращение к Response должно быть одно
            // app.Use(async (context, next) =>
            // {
            //     await context.Response.WriteAsync("<p>Hello world!</p>");
            //     await next.Invoke();
            // });
            //
            // app.Run(async (context) => await context.Response.WriteAsync("<p>Good bye, World...</p>"));

            #endregion

            #region Use

            // var x = 2;
            // app.Use(async (context, next) =>
            // {
            //     x = x * 2;
            //     await next.Invoke();
            //     x = x * 2;
            //     await context.Response.WriteAsync($"Result:{x}");
            // });
            //
            // app.Run(async (context) =>
            // {
            //     x = x * 2;
            //     await Task.FromResult(0);
            // });

            #endregion

            #region Map

            // app.Map("/index", Index);
            // app.Map("/about", About);
            //
            // app.Run(async (context) =>
            // {
            //     await context.Response.WriteAsync("Page Not Found!");
            // });

            // app.Map("/home", home =>
            // {
            //     home.Map("/index", Index);
            //     home.Map("/about", About);
            // });
            //
            // app.Run(async (context) =>
            // {
            //     await context.Response.WriteAsync("Page Not Found - 404");
            // });

            #endregion

            #region MapWhen

            // app.MapWhen(context => context.Request.Query.ContainsKey("id") &&
            //                        context.Request.Query["id"].Equals("5"), HandleId);

            #endregion

            #region Custom component middleware

            // app.UseMiddleware<TokenMiddleware>();
            //
            // app.Run(async context => await context.Response.WriteAsync("Hello World!"));

            #endregion

            #region Add Extensions to TokenMiddleware

            // app.UseToken("12345678");
            //
            // app.Run(async context => await context.Response.WriteAsync("Hello World!"));

            #endregion

            #region Middleware request processing pipeline

            // app.UseMiddleware<ErrorHandingMiddleware>();
            // app.UseMiddleware<AuthenticationMiddleware>();
            // app.UseMiddleware<RoutingMiddleware>();

            #endregion

            #region Custom enviroments
            app.Run(async context =>
            {
                context.Response.Headers["Content-Type"] = "text/html; charset=utf-8";

                if (env.IsEnvironment("Studies")) await context.Response.WriteAsync("В состоянии обучения");
                else await context.Response.WriteAsync("В процессе разработки или в продакшене");
            });


            #endregion
        }

        private static void HandleId(IApplicationBuilder app) =>
            app.Run(async context => await context.Response.WriteAsync("id is equal to 5"));

        private static void Index(IApplicationBuilder app) =>
            app.Run(async (context) =>
                await context.Response.WriteAsync("Index"));

        private static void About(IApplicationBuilder app) =>
            app.Run(async (context) =>
                await context.Response.WriteAsync("About"));
    }
}