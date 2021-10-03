using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Task_13.Models;

namespace Task_13
{
    public class PersonMiddleware
    {
        private readonly RequestDelegate _next;

        public PersonMiddleware(RequestDelegate next, IOptions<Person> options) =>
            (_next, Person) = (next, options.Value);
        
        public Person Person { get; set; }

        public async Task InvokeAsync(HttpContext context)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"<p>Name: {Person?.Name}</p>");
            stringBuilder.Append($"<p>Age: {Person?.Age}</p>");
            stringBuilder.Append($"<p>Company: {Person?.Company?.Title}</p>");
            stringBuilder.Append("<h3>Languages</h3><ul>");

            foreach (var language in Person.Languages)
            {
                stringBuilder.Append($"<li>{language}</li>");
            }
            stringBuilder.Append("</ul>");
 
            await context.Response.WriteAsync(stringBuilder.ToString());
        }
    }
}