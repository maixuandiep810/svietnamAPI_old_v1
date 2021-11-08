using System.Collections.Generic;
using svietnamAPI.Dtos.AppFile;

namespace svietnamAPI.Dtos.Catalog
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BaseImageId { get; set; }
        public int ThumbnailImageId { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsDeleted { get; set; }


        public AppFileDto BaseImage { get; set; }
        public AppFileDto ThumbnailImage { get; set; }
    }
}