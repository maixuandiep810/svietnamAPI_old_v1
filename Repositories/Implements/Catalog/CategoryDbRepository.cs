using System.Net.Mime;
using System.Collections.Generic;
using Dapper;
using System.Linq;
using System.Threading.Tasks;
using svietnamAPI.Infastructure.Data;
using svietnamAPI.Repositories.Interfaces.Catalog;
using svietnamAPI.Dtos.Catalog;
using svietnamAPI.Dtos.StaticFile;

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
            var categories = await GetCategories_Image_Async(CategoryQuery.GetCategories_Image, null);
            return categories;
        }

        private async Task<IEnumerable<CategoryDto>> GetCategories_Image_Async(string query, object queryParams)
        {
            var categories = await WithConnection<IEnumerable<CategoryDto>>(
                async dbConnection =>
                {
                    var records = await dbConnection.QueryAsync<CategoryDto, ImageDto, ImageDto, CategoryDto>(
                        query,
                        (category, baseImage, thumbnailImage) =>
                        {
                            category.BaseImage = baseImage;
                            category.ThumbnailImage = thumbnailImage;
                            return category;
                        },
                        queryParams,
                        splitOn: "ImageId, ImageId"
                    );
                    return records;
                }
            );
            return categories;
        }
    }
}