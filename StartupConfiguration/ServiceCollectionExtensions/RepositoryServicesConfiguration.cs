using Microsoft.Extensions.DependencyInjection;
using svietnamAPI.Repositories.Implements;
using svietnamAPI.Repositories.Interfaces;


namespace svietnamAPI.StartupConfiguration.ServiceCollectionExtensions
{
    public static class RepositoryServicesConfiguration
    {
        public static void AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}