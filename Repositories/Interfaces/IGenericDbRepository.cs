using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;

namespace svietnamAPI.Repositories.Interfaces
{
    public interface IGenericDbRepository : IGenericRepository
    {
        Task<IEnumerable<TEntity>> GetN_Entity_Async<TEntity>(string query, object queryParams);
        Task<TEntity> Get1_Entity_Async<TEntity>(string query, object queryParams);
        Task<int> Create1_Entity_Async(string query, object queryParams);
        Task Update1_Entity_Async(string query, object queryParams);
    }
}