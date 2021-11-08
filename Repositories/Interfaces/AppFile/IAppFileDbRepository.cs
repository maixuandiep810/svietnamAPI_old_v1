using System.Collections.Generic;
using System.Threading.Tasks;
using svietnamAPI.Dtos.AppFile;
using svietnamAPI.Dtos.Catalog;

namespace svietnamAPI.Repositories.Interfaces.AppFile
{
    public interface IAppFileDbRepository : IGenericDbRepository
    {
        Task<int> Create1_Async(string query, AppFileCreateDto createAppFile);
    }
}