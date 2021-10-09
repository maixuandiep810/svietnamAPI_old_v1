using System.Collections.Generic;
using System.Threading.Tasks;
using svietnamAPI.Dtos.Catalog;
using svietnamAPI.Entities.Catalog;

namespace svietnamAPI.Repositories.Interfaces.Catalog
{
    public interface ICategoryRepository : IGenericRepository
    {
        Task<IEnumerable<CategoryEntity>> GetCategoriesAsync();
        Task<IEnumerable<JoinEntity_Category_Image>> GetCategories_Image_Async();
        Task<JoinEntity_Category_Image> GetCategoryById_Image_Async(int categoryId);
    }
}