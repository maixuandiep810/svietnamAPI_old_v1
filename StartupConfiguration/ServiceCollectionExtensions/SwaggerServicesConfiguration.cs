using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;


namespace svietnamAPI.StartupConfiguration.ServiceCollectionExtensions
{
    public static class SwaggerServicesConfiguration
    {
        public static void AddSwaggerServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "svietnamAPI", Version = "v1" });
            });
        }
    }
}