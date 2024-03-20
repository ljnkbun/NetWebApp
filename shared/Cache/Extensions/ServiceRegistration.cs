using Cache.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cache.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddDistributedCache(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMemoryCache();
            services.AddScoped<ICachingService, CachingService>();
        }
    }
}
