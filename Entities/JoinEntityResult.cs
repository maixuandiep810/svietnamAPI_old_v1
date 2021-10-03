using svietnamAPI.Entities.Catalog;
using svietnamAPI.Entities.Image;

namespace svietnamAPI.Entities
{
    public class JoinEntityResult
    {
        public CategoryEntity Category { get; set; }
        public ImageEntity Image { get; set; }
        public ImageAttributeEntity ImageAttribute { get; set; }
    }
}