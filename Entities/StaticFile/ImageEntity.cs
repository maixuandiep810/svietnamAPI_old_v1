namespace svietnamAPI.Entities.StaticFile
{
    public class ImageEntity
    {
        public int ImageId { get; set; }
        public string Filename { get; set; }
        public string Size { get; set; }
        public string RelativeFileLocation { get; set; }
        public string Url { get; set; }
        public bool IsEnabled { get; set; }
    }
}