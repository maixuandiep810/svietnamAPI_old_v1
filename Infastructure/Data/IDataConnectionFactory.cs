using System.Data;

namespace svietnamAPI.Infastructure.Data
{
    public interface IDataConnectionFactory
    {
        IDbConnection CreateDbConnection();
    }
}