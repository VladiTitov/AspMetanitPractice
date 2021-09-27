using Microsoft.AspNetCore.Builder;

namespace Task_01
{
    public static class TokenExtensions
    {
        public static IApplicationBuilder UseToken(this IApplicationBuilder builder, string pattern) =>
            builder.UseMiddleware<TokenMiddleware>(pattern);
    }
}