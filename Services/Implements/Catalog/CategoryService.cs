using svietnamAPI.Services.Interfaces.Catalog;
using svietnamAPI.Repositories.Interfaces.Catalog;
using System.Threading.Tasks;
using System.Collections.Generic;
using svietnamAPI.Dtos.Catalog;
using AutoMapper;
using System.Linq;
using svietnamAPI.Repositories;
using svietnamAPI.Repositories.Interfaces;

namespace svietnamAPI.Services.Implements.Catalog
{
    public partial class CategoryService : BaseService, ICategoryService
    {
        public CategoryService(
            IMapper mapper, IRepositoryWrapper repositoryWrapper
            )
            : base(mapper, repositoryWrapper)
        {
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
        {
            var categories = await _repositoryWrapper.CategoryRepo.GetCategoriesAsync();
            return categories;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategories_Image_Async()
        {
            var categories = await _repositoryWrapper.CategoryRepo.GetCategories_Image_Async();
            return categories;
        }

    }
}