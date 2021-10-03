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
using Task_12.Models;

namespace Task_12
{
    public class Startup
    {
        public Startup()
        {
            #region For json 
            var builder = new ConfigurationBuilder()
                .AddJsonFile("personNew.json");
            #endregion

            #region For XML

            // var builder = new ConfigurationBuilder()
            //     .AddXmlFile("person.xml");
            #endregion
            
            
            AppConfiguration = builder.Build();
        }
        
        public IConfiguration AppConfiguration { get; set; }
        
        public void ConfigureServices(IServiceCollection services) { }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // var tom = new PersonNew();
            // AppConfiguration.Bind(tom);

            var tom = AppConfiguration.Get<PersonNew>();

            var company = AppConfiguration.GetSection("company").Get<Company>();
            
            app.Run(async context =>
            {
                //await context.Response.WriteAsync($"<p>Name: {tom.Name}</p><p>Age: {tom.Age}</p>");
                string name = $"<p>Name: {tom.Name}</p>";
                string age = $"<p>Age: {tom.Age}</p>";
                //string company = $"<p>Company: {tom.Company?.Title}</p>";
                string companyName = $"<p>Company: {company.Title}</p>";
                string companyCountry = $"<p>Country: {company.Country}</p>";
                string languages = "<p>Languages</p><ul>";
                foreach (var language in tom.Languages)
                {
                    languages += $"<li><p>{language}</p></li>";
                }
                languages += "</ul>";

                await context.Response.WriteAsync($"{name} {age} {companyName} {companyCountry} {languages}");
            });
        }
    }
}