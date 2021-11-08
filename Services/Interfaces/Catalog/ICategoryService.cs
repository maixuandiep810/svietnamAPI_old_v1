using System.Threading.Tasks;
using System.Collections.Generic;
using svietnamAPI.Dtos.Catalog;
using Microsoft.AspNetCore.Http;

namespace svietnamAPI.Services.Interfaces.Catalog
{
    public interface ICategoryService : IBaseService
    {
        Task<IEnumerable<CategoryDto>>  GetN_Basic_Async();
        Task<IEnumerable<CategoryDto>> GetN_Image_Async();
        Task<CategoryDto> Get1_ById_Basic_Async(int categoryId);
        Task<CategoryDto>  Get1_ById_Image_Async(int categoryId);
        Task<bool> UpdateCategoryBaseImageAsync(int categoryId, IFormFile formFile);
    }
}