using System.Collections.Generic;
namespace svietnamAPI.Dtos.AppFile
{
    public class AppFileDto
    {
        public int AppFileId { get; set; }
        public string Filename { get; set; }
        public string Location { get; set; }
        public string Url { get; set; }
        public string AppFileType { get; set; }
        public bool IsEnabled { get; set; }
    }
}