using System.Threading.Tasks;
using System.Collections.Generic;
using svietnamAPI.Dtos.Catalog;
using Microsoft.AspNetCore.Http;

namespace svietnamAPI.Services.Interfaces.Catalog
{
    public interface ICategoryService : IBaseService
    {
        Task<IEnumerable<CategoryDto>> GetCategoriesAsync();
        Task<IEnumerable<CategoryDto>> GetCategories_Image_Async();
        Task<CategoryDto> GetCategoryByIdAsync(int categoryId);
        Task<CategoryDto> GetCategoryById_Image_Async(int categoryId);
        Task<bool> UpdateCategoryBaseImageAsync(int categoryId, IFormFile formFile);
    }
}