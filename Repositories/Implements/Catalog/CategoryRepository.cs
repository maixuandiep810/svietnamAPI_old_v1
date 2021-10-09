using System.Collections.Generic;
using Dapper;
using System.Linq;
using System.Threading.Tasks;
using svietnamAPI.Infastructure.Data;
using svietnamAPI.Repositories.Interfaces.Catalog;
using svietnamAPI.Entities.Catalog;
using svietnamAPI.Entities;
using svietnamAPI.Entities.StaticFile;
using svietnamAPI.Dtos.Catalog;

namespace svietnamAPI.Repositories.Implements.Catalog
{
    public partial class CategoryRepository : GenericRepository, ICategoryRepository
    {
        public CategoryRepository(IDataConnectionFactory dataConnectionFactory)
        : base(dataConnectionFactory)
        {
        }


        public async Task<IEnumerable<CategoryEntity>> GetCategoriesAsync()
        {
            var query = "SELECT * FROM Category";
            var categories = await GetEntitiesAsync<CategoryEntity>(query, null);
            return categories;
        }


        public async Task<IEnumerable<JoinEntity_Category_Image>> GetCategories_Image_Async()
        {
            var query = @"SELECT * FROM Category c
                        LEFT JOIN Image ib ON c.BaseImageId = ib.ImageId
                        LEFT JOIN Image it ON c.ThumbnailImageId = it.ImageId";
            var joinEntities = await GetCategories_Image_Async(query, null);
            return joinEntities;
        }

        public async Task<JoinEntity_Category_Image> GetCategoryById_Image_Async(int categoryId)
        {
            var query = @"SELECT * FROM Category c
                        LEFT JOIN Image ib ON c.BaseImageId = ib.ImageId
                        LEFT JOIN Image it ON c.ThumbnailImageId = it.ImageId
                        WHERE c.CategoryId=@CategoryId";
            var queryParams = new DynamicParameters();
            queryParams.Add("CategoryId", categoryId);
            var joinEntities = await GetCategories_Image_Async(query, queryParams);
            var joinEntityFirst = joinEntities.FirstOrDefault();
            return joinEntityFirst;
        }



        private async Task<IEnumerable<JoinEntity_Category_Image>> GetCategories_Image_Async(string query, DynamicParameters queryParams)
        {
            IEnumerable<JoinEntity_Category_Image> joinEntities = null;
            using (var dbConnection = _dataConnectionFactory.CreateDbConnection())
            {
                dbConnection.Open();
                joinEntities = await dbConnection.QueryAsync<CategoryEntity, ImageEntity, ImageEntity, JoinEntity_Category_Image>(
                    query,
                    (category, baseImage, thumbnailImage) =>
                    {
                        var joinEntity = new JoinEntity_Category_Image();
                        joinEntity.Category = category;
                        joinEntity.BaseImage = baseImage;
                        joinEntity.ThumbnailImage = thumbnailImage;
                        return joinEntity;
                    },
                    queryParams,
                    splitOn: "ImageId, ImageId"
                    );
            }
            return joinEntities;
        }

    }
}