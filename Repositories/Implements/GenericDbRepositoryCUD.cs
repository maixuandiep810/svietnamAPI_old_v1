using System.Collections.Generic;
using Dapper;
using System.Linq;
using System.Threading.Tasks;
using svietnamAPI.Repositories.Interfaces;
using svietnamAPI.Infastructure.Data;

namespace svietnamAPI.Repositories.Implements
{
    // Use for Tasks of Reading entities 
    public abstract partial class GenericDbRepository
    {
        /// <summary>
        /// Save -Entity- to Database 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        public async Task<int> Create1_Entity_Async(string query, object queryParams)
        {
            var insertedId = await WithConnection<int>(
                async dbConnection =>
                {
                    var record = await dbConnection.QuerySingleOrDefaultAsync<int>(query, queryParams);
                    return record;
                }
            );
            return insertedId;
        }

        /// <summary>
        /// Update -entity- to Database
        /// </summary>
        /// <param name="query"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        public async Task Update1_Entity_Async(string query, object queryParams)
        {
            await WithConnection(
                async dbConnection =>
                {
                    await dbConnection.ExecuteReaderAsync(query, queryParams);
                }
            );
        }


    }
}
