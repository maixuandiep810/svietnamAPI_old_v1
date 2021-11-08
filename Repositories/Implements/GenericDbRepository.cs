using System.Threading.Tasks;
using svietnamAPI.Repositories.Interfaces;
using svietnamAPI.Infastructure.Data;
using System;
using System.Data.SqlClient;
using System.Data;

namespace svietnamAPI.Repositories.Implements
{
    public abstract partial class GenericDbRepository : GenericRepository, IGenericDbRepository
    {
        public GenericDbRepository(IDataConnectionFactory dataConnectionFactory)
    : base(dataConnectionFactory)
        {

        }

        // use for buffered queries that return a type
        protected async Task<TRead> WithConnection<TRead>(Func<IDbConnection, Task<TRead>> queryData)
        {
            await using (var dbConnection = _dataConnectionFactory.CreateSqlDbConnection())
            {
                await dbConnection.OpenAsync();
                return await queryData(dbConnection);
            }
        }

        // use for buffered queries that do not return a type
        protected async Task WithConnection(Func<IDbConnection, Task> queryData)
        {
            await using (var dbConnection = _dataConnectionFactory.CreateSqlDbConnection())
            {
                await dbConnection.OpenAsync();
                await queryData(dbConnection);
            }
        }

        //use for non-buffered queries that return a type
        protected async Task<TAfterProcess> WithConnection<TRead, TAfterProcess>(Func<IDbConnection, Task<TRead>> queryData, Func<TRead, TAfterProcess> processAfterQuery)
        {
            await using (var dbConnection = _dataConnectionFactory.CreateSqlDbConnection())
            {
                await dbConnection.OpenAsync();
                var data = await queryData(dbConnection);
                return processAfterQuery(data);
            }
        }
    }
}