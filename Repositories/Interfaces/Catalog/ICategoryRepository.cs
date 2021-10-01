using System.Collections.Generic;
using System.Threading.Tasks;
using svietnamAPI.Dtos.Catalog;

namespace svietnamAPI.Repositories.Interfaces.Catalog
{
    public interface ICategoryRepository : IGenericRepository
    {
        Task<IEnumerable<CategoryDto>> GetCategoriesAsync();
    }
}