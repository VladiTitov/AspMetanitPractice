using Microsoft.Extensions.DependencyInjection;

namespace Task_04.Services
{
    public static class ServiceProviderExtensions
    {
        public static void AddTimeService(this IServiceCollection services) => 
            services.AddTransient<TimeService>();
    }
}