using svietnamAPI.Services.Interfaces.Catalog;
using svietnamAPI.Repositories.Interfaces.Catalog;
using System.Threading.Tasks;
using System.Collections.Generic;
using svietnamAPI.Dtos.Catalog;
using AutoMapper;
using System.Linq;
using svietnamAPI.Repositories;
using svietnamAPI.Repositories.Interfaces;
using svietnamAPI.Services.Interfaces;

namespace svietnamAPI.Services.Implements.Catalog
{
    public partial class CategoryService : BaseService, ICategoryService
    {
        public CategoryService(IMapper mapper, IRepositoryWrapper repositoryWrapper, IServiceWrapper serviceWrapper)
            : base(mapper, repositoryWrapper, serviceWrapper)
        {
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
        {
            var categories = await _repositoryWrapper.CategoryDbRepo.GetCategoriesAsync();
            return categories;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategories_Image_Async()
        {
            var categories = await _repositoryWrapper.CategoryDbRepo.GetCategories_Image_Async();
            return categories;
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int categoryId)
        {
            var category = await _repositoryWrapper.CategoryDbRepo.GetCategoryByIdAsync(categoryId);
            return category;
        }

        public async Task<CategoryDto> GetCategoryById_Image_Async(int categoryId)
        {
            var category = await _repositoryWrapper.CategoryDbRepo.GetCategoryById_Image_Async(categoryId);
            return category;
        }


    }
}   