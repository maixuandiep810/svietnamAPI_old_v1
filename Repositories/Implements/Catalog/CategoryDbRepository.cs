using System.Collections.Generic;
using Dapper;
using System.Threading.Tasks;
using svietnamAPI.Infastructure.Data;
using svietnamAPI.Repositories.Interfaces.Catalog;
using svietnamAPI.Dtos.Catalog;
using svietnamAPI.Dtos.AppFile;
using svietnamAPI.Dtos.ValueDtos;
using System.Linq;

namespace svietnamAPI.Repositories.Implements.Catalog
{
    public partial class CategoryDbRepository : GenericDbRepository, ICategoryDbRepository
    {
        public CategoryDbRepository(IDataConnectionFactory dataConnectionFactory)
        : base(dataConnectionFactory)
        {
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
        {
            var categories = await GetEntitiesAsync<CategoryDto>(CategoryQuery.GetCategories, null);
            return categories;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategories_Image_Async()
        {
            var queryParams = new
            {
                BaseImageType = AppFileType.Image,
                ThumbnailImageType = AppFileType.Image
            };
            var categories = await GetCategories_Image_Async(CategoryQuery.GetCategories_Image, queryParams);
            return categories;
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int categoryId)
        {
            var category = await GetEntityAsync<CategoryDto>(CategoryQuery.GetCategoryById, new { CategoryId = categoryId });
            return category;
        }

        public async Task<CategoryDto> GetCategoryById_Image_Async(int categoryId)
        {
            var queryParams = new
            {
                CategoryId = categoryId,
                BaseImageType = AppFileType.Image,
                ThumbnailImageType = AppFileType.Image
            };
            var categories = await GetCategories_Image_Async(CategoryQuery.GetCategoryById_Image, queryParams);
            if (categories == null)
                return null;
            var category = categories.FirstOrDefault();
            return category;
        }

        private async Task<IEnumerable<CategoryDto>> GetCategories_Image_Async(string query, object queryParams)
        {
            var categories = await WithConnection<IEnumerable<CategoryDto>>(
                async dbConnection =>
                {
                    var records = await dbConnection.QueryAsync<CategoryDto, AppFileDto, AppFileDto, CategoryDto>(
                        query,
                        (category, baseImage, thumbnailImage) =>
                        {
                            category.BaseImage = baseImage;
                            category.ThumbnailImage = thumbnailImage;
                            return category;
                        },
                        queryParams,
                        splitOn: "AppFileId, AppFileId"
                    );
                    return records;
                }
            );
            return categories;
        }
    }
}