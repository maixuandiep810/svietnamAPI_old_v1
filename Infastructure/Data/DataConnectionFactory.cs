using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using svietnamAPI.StartupConfiguration.AppSetting;

namespace svietnamAPI.Infastructure.Data
{
    public class DataConnectionFactory : IDataConnectionFactory
    {
        private readonly ServerSetting _serverSetting;
        private readonly string _DbConnectionString;

        public DataConnectionFactory(IOptions<ServerSetting> serverSetting)
        {
            _serverSetting = serverSetting.Value;
            _DbConnectionString = _serverSetting.DataConnection.DbConnectionString;
        }

        public IDbConnection CreateDbConnection()
        {
            IDbConnection connection = new SqlConnection(_DbConnectionString);
            return connection;
        }
    }
}

