namespace svietnamAPI.Repositories.Implements.Catalog
{
    public static class CategoryQuery
    {
        public const string GetCategories = "SELECT * FROM Category";
        public const string GetCategories_Image = @"
                        SELECT * FROM Category c
                        LEFT JOIN AppFile afb ON c.BaseImageId = afb.AppFileId
                        LEFT JOIN AppFile aft ON c.ThumbnailImageId = aft.AppFileId
                        WHERE 
                        afb.AppFileType=@BaseImageType AND
                        aft.AppFileType=@ThumbnailImageType
                        ;";
        public const string GetCategoryById = @"
                        SELECT * FROM Category
                        WHERE CategoryId=@CategoryId
                        ;";
        public const string GetCategoryById_Image = @"
                        SELECT * FROM Category c
                        LEFT JOIN AppFile afb ON c.BaseImageId = afb.AppFileId
                        LEFT JOIN AppFile aft ON c.ThumbnailImageId = aft.AppFileId
                        WHERE 
                        c.CategoryId=@CategoryId AND
                        afb.AppFileType=@BaseImageType AND
                        aft.AppFileType=@ThumbnailImageType
                        ;";

        public const string UpdateCategory = @"
                        UPDATE Category
                        SET 
                        Name=@Name, 
                        Description=@Description, 
                        BaseImageId=@BaseImageId, 
                        ThumbnailImageId=@ThumbnailImageId, 
                        IsEnabled=@IsEnabled
                        WHERE CategoryId=@CategoryId
                        ;";//


    }
}