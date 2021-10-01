using System.Threading.Tasks;
using System.Collections.Generic;
using svietnamAPI.Dtos.Catalog;

namespace svietnamAPI.Services.Interfaces.Catalog
{
    public interface ICategoryService : IBaseService
    {
        Task<IEnumerable<CategoryDto>> GetCategoriesAsync();
    }
}