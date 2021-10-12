using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Task_18
{
    public class CustomConstraint : IRouteConstraint
    {
        private readonly string _uri;

        public CustomConstraint(string uri) => _uri = uri;

        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values,
            RouteDirection routeDirection) => !(_uri.Equals(httpContext?.Request.Path));
    }
}