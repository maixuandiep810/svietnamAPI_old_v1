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
        public CategoryDbRepository(IDataConnectionFactory dataConnectionFactory) : base(dataConnectionFactory)
        {
        }

        public async Task<IEnumerable<CategoryDto>> GetN_Basic_Async(string query, string slug = null)
        {
            var queryParams = new
            {
                Slug = slug
            };
            var categories = await GetN_Entity_Async<CategoryDto>(query, queryParams);
            return categories;
        }

        public async Task<IEnumerable<CategoryDto>> GetN_AppFile_Async(string query, string slug = null)
        {
            var queryParams = new
            {
                BaseImageType = AppFileType.Image.ToString(),
                ThumbnailImageType = AppFileType.Image.ToString(),
                Slug = slug
            };
            var categories = await GetN_AppFile_Async(CategoryDbQuery.GetN_AppFile, queryParams);
            return categories;
        }

        public async Task<CategoryDto> Get1_Basic_Async(string query, int? categoryId = null, string slug = null)
        {
            var queryParams = new
            {
                CategoryId = categoryId,
                Slug = slug
            };
            var category = await Get1_Entity_Async<CategoryDto>(query, queryParams);
            return category;
        }

        public async Task<CategoryDto> Get1_AppFile_Async(string query, int? categoryId = null, string slug = null)
        {
            var queryParams = new
            {
                CategoryId = categoryId,
                BaseImageType = AppFileType.Image.ToString(),
                ThumbnailImageType = AppFileType.Image.ToString(),
                Slug = slug
            };
            var categories = await GetN_AppFile_Async(query, queryParams);
            var category = categories?.FirstOrDefault();
            return category;
        }

        private async Task<IEnumerable<CategoryDto>> GetN_AppFile_Async(string query, object queryParams)
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