using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using svietnamAPI.StartupConfiguration.AppSetting;

namespace svietnamAPI.StartupConfiguration.ApplicationBuilderExtensions
{
    public static class UseStaticFilesExtension
    {
        public static void UseAppStaticFiles(this IApplicationBuilder app)
        {
            var serverSetting = (app.ApplicationServices.GetRequiredService<IOptions<ServerSetting>>()).Value;
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(serverSetting.StaticFileInfo.BaseLocation),
                RequestPath = "/StaticFiles"
            });
        }
    }
}