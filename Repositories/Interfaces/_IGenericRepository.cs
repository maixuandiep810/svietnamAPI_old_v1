using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;

namespace svietnamAPI.Repositories.Interfaces
{
    public interface IGenericRepository
    {

        Task<IEnumerable<TEntity>> GetEntitiesAsync<TEntity>(string query, DynamicParameters queryParams);
    }
}