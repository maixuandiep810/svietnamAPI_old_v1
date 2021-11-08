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
using svietnamAPI.Repositories.Implements.Catalog;
namespace svietnamAPI.Services.Implements.Catalog
{
    public partial class CategoryService : BaseService, ICategoryService
    {
        public CategoryService(IMapper mapper, IRepositoryWrapper repositoryWrapper, IServiceWrapper serviceWrapper)
            : base(mapper, repositoryWrapper, serviceWrapper)
        {
        }

        public async Task<IEnumerable<CategoryDto>> GetN_Basic_Async()
        {
            var categories = await _repositoryWrapper.CategoryDbRepo.GetN_Basic_Async(CategoryDbQuery.GetN_Basic);
            return categories;
        }

        public async Task<IEnumerable<CategoryDto>> GetN_Image_Async()
        {
            var categories = await _repositoryWrapper.CategoryDbRepo.GetN_AppFile_Async(CategoryDbQuery.GetN_AppFile);
            return categories;
        }

        public async Task<CategoryDto> Get1_ById_Basic_Async(int categoryId)
        {
            var category = await _repositoryWrapper.CategoryDbRepo.Get1_Basic_Async(CategoryDbQuery.Get1_ById_Basic, categoryId: categoryId);
            return category;
        }

        public async Task<CategoryDto> Get1_ById_Image_Async(int categoryId)
        {
            var category = await _repositoryWrapper.CategoryDbRepo.Get1_AppFile_Async(CategoryDbQuery.Get1_ById_AppFile, categoryId: categoryId);
            return category;
        }


    }
}   