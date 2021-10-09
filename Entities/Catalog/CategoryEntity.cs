using System.Collections.Generic;

namespace svietnamAPI.Entities.Catalog
{
    public class CategoryEntity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BaseImageId { get; set; }
        public int ThumbnailImageId { get; set; }
        public bool IsEnabled { get; set; }
    }
}