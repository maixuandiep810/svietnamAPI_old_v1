using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using svietnamAPI.Infastructure.Data;
using svietnamAPI.StartupConfiguration.AppSetting;

namespace svietnamAPI.StartupConfiguration.ApplicationBuilderExtensions
{
    public static class PrepareInfrastuctureServicesExtension
    {
        public static void PrepareInfrastuctureServices(this IApplicationBuilder app)
        {
            var dataConnectionFactory = app.ApplicationServices.GetRequiredService<IDataConnectionFactory>();
            dataConnectionFactory.PrepareSqlDatabase();
            dataConnectionFactory.PrepareStaticFilesFolder();
        }
    }
}