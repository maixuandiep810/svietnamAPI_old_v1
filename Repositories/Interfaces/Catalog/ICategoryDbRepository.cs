using System.Collections.Generic;
using System.Threading.Tasks;
using svietnamAPI.Dtos.Catalog;

namespace svietnamAPI.Repositories.Interfaces.Catalog
{
    public interface ICategoryDbRepository : IGenericDbRepository
    {
        Task<IEnumerable<CategoryDto>> GetN_Basic_Async(string query, string slug = null);
        Task<IEnumerable<CategoryDto>> GetN_AppFile_Async(string query, string slug = null);
        Task<CategoryDto> Get1_Basic_Async(string query, int? categoryId = null, string slug = null);
        Task<CategoryDto> Get1_AppFile_Async(string query, int? categoryId = null, string slug = null);
        Task Update1_Async(string query, CategoryUpdateDto updateCategory);
    }
}