using System.Collections.Generic;
namespace svietnamAPI.Dtos.StaticFile
{
    public class ImageDto
    {
        public int ImageId { get; set; }
        public string Filename { get; set; }
        public string Size { get; set; }
        public string RelativeFileLocation { get; set; }
        public string Url { get; set; }
        public bool IsEnabled { get; set; }
    }
}