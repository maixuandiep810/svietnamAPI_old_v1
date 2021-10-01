using System.Collections.Generic;
using svietnamAPI.Dtos.Image;

namespace svietnamAPI.Dtos.Catalog
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; }
        public string Description { get; set; }

        public List<ImageDto> Images { get; set; } = new List<ImageDto>();
    }
}