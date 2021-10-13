namespace svietnamAPI.Repositories.Implements.Catalog
{
    public static class CategoryQuery
    {
        public const string GetCategories = "SELECT * FROM Category";
        public const string GetCategories_Image = @"
                        SELECT * FROM Category c
                        LEFT JOIN Image ib ON c.BaseImageId = ib.ImageId
                        LEFT JOIN Image it ON c.ThumbnailImageId = it.ImageId";
        public const string GetCategoryById_Image = @"
                        SELECT * FROM Category c
                        LEFT JOIN Image ib ON c.BaseImageId = ib.ImageId
                        LEFT JOIN Image it ON c.ThumbnailImageId = it.ImageId
                        WHERE c.CategoryId=@CategoryId";
    }
}