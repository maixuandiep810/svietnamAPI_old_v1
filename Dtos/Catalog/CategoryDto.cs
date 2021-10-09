using System.Collections.Generic;
using svietnamAPI.Dtos.StaticFile;

namespace svietnamAPI.Dtos.Catalog
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEnabled { get; set; }
        public ImageDto BaseImage { get; set; }
        public ImageDto ThumbnailImage { get; set; }
    }
}