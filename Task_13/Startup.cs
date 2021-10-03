using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Task_13.Models;

namespace Task_13
{
    public class Startup
    {
        public Startup()
        {
            var biulder = new ConfigurationBuilder()
                .AddJsonFile("person.json");
            AppConfiguration = biulder.Build();
        }
        
        public IConfiguration AppConfiguration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<Person>(AppConfiguration);
            services.Configure<Person>(opt =>
            {
                opt.Age = 18;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<PersonMiddleware>();
        }
    }
}