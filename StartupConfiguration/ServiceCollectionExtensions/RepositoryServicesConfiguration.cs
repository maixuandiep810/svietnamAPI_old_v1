using Microsoft.Extensions.DependencyInjection;
using svietnamAPI.Repositories.Implements.Catalog;
using svietnamAPI.Repositories.Interfaces.Catalog;


namespace svietnamAPI.StartupConfiguration.ServiceCollectionExtensions
{
    public static class RepositoryServicesConfiguration
    {
        public static void AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }
    }
}