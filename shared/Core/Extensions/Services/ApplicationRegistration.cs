using Core.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Core.Extensions.Services
{
    public static class ApplicationRegistration
    {
        public static void UseSharedMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
