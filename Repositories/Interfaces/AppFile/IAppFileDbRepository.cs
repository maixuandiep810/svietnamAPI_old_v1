using System.Collections.Generic;
using System.Threading.Tasks;
using svietnamAPI.Dtos.AppFile;
using svietnamAPI.Dtos.Catalog;

namespace svietnamAPI.Repositories.Interfaces.AppFile
{
    public interface IAppFileDbRepository : IGenericDbRepository
    {
        Task<int> CreateAppFileAsync(CreateAppFileDto createAppFile);
    }
}