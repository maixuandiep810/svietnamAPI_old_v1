using System.Collections.Generic;
using System.Threading.Tasks;
using svietnamAPI.Entities.Catalog;

namespace svietnamAPI.Repositories.Interfaces.Catalog
{
    public interface ICategoryRepository : IGenericRepository
    {
        Task<IEnumerable<CategoryEntity>> GetCategoriesAsync();
    }
}