using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;

namespace svietnamAPI.Repositories.Interfaces
{
    public interface IGenericDbRepository : IGenericRepository
    {
        Task<IEnumerable<TEntity>> GetEntitiesAsync<TEntity>(string query, object queryParams);
        Task<TEntity> GetEntityAsync<TEntity>(string query, object queryParams);
        Task<int> CreateEntityAsync(string query, object queryParams);
        Task UpdateEntityAsync(string query, object queryParams);
    }
}