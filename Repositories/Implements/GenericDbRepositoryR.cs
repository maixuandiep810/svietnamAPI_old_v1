using System.Collections.Generic;
using Dapper;
using System.Linq;
using System.Threading.Tasks;
using svietnamAPI.Repositories.Interfaces;
using svietnamAPI.Infastructure.Data;

namespace svietnamAPI.Repositories.Implements
{
    // Use for Tasks of Reading entities 
    public abstract partial class GenericDbRepository : GenericRepository, IGenericDbRepository
    {
        /// <summary>
        /// Get records or null
        /// </summary>
        /// <param name="query"></param>
        /// <param name="queryParams"></param>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> GetEntitiesAsync<TEntity>(string query, object queryParams)
        {
            var entities = await WithConnection<IEnumerable<TEntity>>(
                async dbConnection =>
                {
                    var records = await dbConnection.QueryAsync<TEntity>(query, queryParams);
                    return records;
                }
            );
            return entities;
        }
        
        /// <summary>
        /// Get first record or default value
        /// </summary>
        /// <param name="query"></param>
        /// <param name="queryParams"></param>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public async Task<TEntity> GetEntityAsync<TEntity>(string query, object queryParams)
        {
            var entity = await WithConnection<TEntity>(
                async dbConnection =>
                {
                    var record = await dbConnection.QueryFirstOrDefaultAsync<TEntity>(query, queryParams);
                    return record;
                }
            );
            return entity;
        }
    }
}
