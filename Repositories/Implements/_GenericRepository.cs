using System.Collections.Generic;
using Dapper;
using System.Linq;
using System.Threading.Tasks;
using svietnamAPI.Repositories.Interfaces;
using svietnamAPI.Infastructure.Data;

namespace svietnamAPI.Repositories.Implements
{
    public abstract class GenericRepository : IGenericRepository
    {
        protected readonly IDataConnectionFactory _dataConnectionFactory;

        public GenericRepository(IDataConnectionFactory dataConnectionFactory)
        {
            _dataConnectionFactory = dataConnectionFactory;
        }

        public async Task<IEnumerable<TEntity>> GetEntitiesAsync<TEntity>(string query, DynamicParameters queryParams = null)
        {
            IEnumerable<TEntity> entityRecords;
            using (var dbConnection = _dataConnectionFactory.CreateDbConnection())
            {
                dbConnection.Open();
                entityRecords = await dbConnection.QueryAsync<TEntity>(query, queryParams);
            }
            return entityRecords;
        }
    }
}