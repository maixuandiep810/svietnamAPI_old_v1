using System.Collections.Generic;
namespace svietnamAPI.Dtos.AppFile
{
    public class CreateAppFileDto
    {
        public string Filename { get; set; }
        public string Location { get; set; }
        public string Url { get; set; }
        public string AppFileType { get; set; }
        public bool IsEnabled { get; set; }
    }
}