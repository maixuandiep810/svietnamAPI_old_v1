using svietnamAPI.Services.Interfaces.Catalog;
using svietnamAPI.Repositories.Interfaces.Catalog;
using System.Threading.Tasks;
using System.Collections.Generic;
using svietnamAPI.Dtos.Catalog;
using AutoMapper;

namespace svietnamAPI.Services.Implements.Catalog
{
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo;

        public CategoryService(
            IMapper mapper, 
            ICategoryRepository categoryRepo) 
            : base (mapper)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync() {
            var categoryEntities = await _categoryRepo.GetCategoriesAsync();
            var categoryDtos = _mapper.Map<IEnumerable<CategoryDto>>(categoryEntities);
            return categoryDtos;
        }
    }
}