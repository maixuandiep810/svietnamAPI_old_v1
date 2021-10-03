using System.Collections.Generic;
namespace svietnamAPI.Entities.Image
{
    public class ImageEntity
    {
        public int ImageId { get; set; }
        public string Filename { get; set; }
        public string EntityType { get; set; }
        public int EntityId { get; set; }
        public string Location { get; set; }
        public string Url { get; set; }
        public string Size { get; set; }
    }
}