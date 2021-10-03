using System.Collections.Generic;
using svietnamAPI.Dtos.Image;

namespace svietnamAPI.Entities.Catalog
{
    public class CategoryEntity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; }
        public string Description { get; set; }
    }
}