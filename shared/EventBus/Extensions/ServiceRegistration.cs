using EventBus.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EventBus.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddEventBusService(this IServiceCollection services)
        {
            services.AddTransient<IRequestClientService, RequestClientService>();
        }
    }
}
