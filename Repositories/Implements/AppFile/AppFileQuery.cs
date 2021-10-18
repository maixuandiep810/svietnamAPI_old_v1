namespace svietnamAPI.Repositories.Implements.AppFile
{
    public static class AppFileQuery
    {
        public const string CreateAppFile = @"
                        INSERT INTO AppFile
                        (Filename, Location, Url, AppFileType, IsEnabled)
                        VALUES
                        (@Filename, @Location, @Url, @AppFileType, @IsEnabled)
                        ;
                        SELECT CAST(SCOPE_IDENTITY() as int)
                        ;";

        public const string updateAppFile = @"
                        UPDATE AppFile
                        SET 
                        Filename=@Filename, 
                        Location=@Location, 
                        Url=@Url, 
                        AppFileType=@AppFileType, 
                        IsEnabled=@IsEnabled
                        WHERE AppFileId=@AppFileId
                        ;
                        SELECT CAST(SCOPE_IDENTITY() as int)
                        ;";


    }
}