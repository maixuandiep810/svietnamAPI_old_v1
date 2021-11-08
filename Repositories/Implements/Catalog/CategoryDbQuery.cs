namespace svietnamAPI.Repositories.Implements.Catalog
{
    public static class CategoryDbQuery
    {
        public const string GetN_Basic =
        @"SELECT * FROM Category
        ;";

        public const string GetN_AppFile =
        @"SELECT * FROM Category c
        LEFT JOIN AppFile afb ON c.BaseImageId = afb.AppFileId
        LEFT JOIN AppFile aft ON c.ThumbnailImageId = aft.AppFileId
        WHERE 
        afb.AppFileType=@BaseImageType AND
        aft.AppFileType=@ThumbnailImageType
        ;";

        public const string Get1_ById_Basic =
        @"SELECT * FROM Category
        WHERE CategoryId=@CategoryId
        ;";

        public const string Get1_ById_AppFile =
        @"SELECT * FROM Category c
        LEFT JOIN AppFile afb ON c.BaseImageId = afb.AppFileId
        LEFT JOIN AppFile aft ON c.ThumbnailImageId = aft.AppFileId
        WHERE 
        c.CategoryId=@CategoryId AND
        afb.AppFileType=@BaseImageType AND
        aft.AppFileType=@ThumbnailImageType
        ;";

        public const string Update1 =
        @"UPDATE Category
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