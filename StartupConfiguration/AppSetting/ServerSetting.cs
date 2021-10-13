namespace svietnamAPI.StartupConfiguration.AppSetting
{
    public class ServerSetting
    {
        public JwtInfo JwtInfo { get; set; }
        public StaticFileInfo StaticFileInfo { get; set; }
        public HostInfo HostInfo { get; set; }
        public DataConnection DataConnection { get; set; }
    }
}