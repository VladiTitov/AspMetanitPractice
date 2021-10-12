using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Task_18
{
    public class PositionConstraint : IRouteConstraint
    {
        private string[] positions = new[] { "admin", "director", "accountant"};
        
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values,
            RouteDirection routeDirection) => positions.Contains(values[routeKey]?.ToString()?.ToLowerInvariant());
    }
}