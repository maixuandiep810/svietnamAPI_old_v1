using AutoMapper;
using svietnamAPI.Dtos.StaticFile;
using svietnamAPI.Entities.Catalog;
using svietnamAPI.Entities.StaticFile;

namespace svietnamAPI.Entities.Catalog
{
    public class JoinEntity_Category_Image
    {
        public CategoryEntity Category { get; set; }
        public ImageEntity BaseImage { get; set; }
        public ImageEntity ThumbnailImage { get; set; }
    }
}