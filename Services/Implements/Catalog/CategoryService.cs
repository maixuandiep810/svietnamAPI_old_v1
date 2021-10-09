using svietnamAPI.Services.Interfaces.Catalog;
using svietnamAPI.Repositories.Interfaces.Catalog;
using System.Threading.Tasks;
using System.Collections.Generic;
using svietnamAPI.Dtos.Catalog;
using AutoMapper;
using System.Linq;

namespace svietnamAPI.Services.Implements.Catalog
{
    public partial class CategoryService : BaseService, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo;

        public CategoryService(
            IMapper mapper,
            ICategoryRepository categoryRepo)
            : base(mapper)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
        {
            var categoryEntities = await _categoryRepo.GetCategoriesAsync();
            var categoryDtos = _mapper.Map<IEnumerable<CategoryDto>>(categoryEntities);
            return categoryDtos;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategories_Image_Async()
        {
            var joinEntities = await _categoryRepo.GetCategories_Image_Async();
            var joinDtos = _mapper.Map<IEnumerable<JoinDto_Category_Image>>(joinEntities);
            var categories = joinDtos.Select(p => p.Category);
            return categories;
        }

        public async Task<CategoryDto> GetCategoryById_Image_Async(int categoryId)
        {
            var joinEntity = await _categoryRepo.GetCategoryById_Image_Async(categoryId);
            var joinDto = _mapper.Map<JoinDto_Category_Image>(joinEntity);
            var category = joinDto.Category;
            return category;
        }

    }
}