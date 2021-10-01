using Microsoft.Extensions.DependencyInjection;
using svietnamAPI.Infastructure.Data;
using svietnamAPI.Infastructure.AutoMapper;
using AutoMapper;

namespace svietnamAPI.StartupConfiguration.ServiceCollectionExtensions
{
    public static class InfastructureServicesConfiguration
    {
        public static void AddInfastructureServices(this IServiceCollection services)
        {
            // DataConnection
            services.AddSingleton<IDataConnectionFactory, DataConnectionFactory>();

            // AutoMapper
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            mappingConfig.AssertConfigurationIsValid();
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}