using System.Collections.Generic;
using System.Threading.Tasks;
using svietnamAPI.Dtos.Catalog;

namespace svietnamAPI.Repositories.Interfaces.Catalog
{
    public interface ICategoryDbRepository : IGenericDbRepository
    {
        Task<IEnumerable<CategoryDto>> GetCategoriesAsync();
        Task<IEnumerable<CategoryDto>> GetCategories_Image_Async();
    }
}