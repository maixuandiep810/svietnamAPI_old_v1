using Microsoft.Extensions.DependencyInjection;
using svietnamAPI.Services.Implements.Catalog;
using svietnamAPI.Services.Interfaces.Catalog;


namespace svietnamAPI.StartupConfiguration.ServiceCollectionExtensions
{
    public static class BusinessServicesConfiguration
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
        }
    }
}