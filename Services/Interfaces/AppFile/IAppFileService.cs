using System.Threading.Tasks;
using System.Collections.Generic;
using svietnamAPI.Dtos.Catalog;
using Microsoft.AspNetCore.Http;

namespace svietnamAPI.Services.Interfaces.AppFile
{
    public interface IAppFileService : IBaseService
    {
        Task<int> SaveAppFileAsync(IFormFile formFile, string appFileType, int physicalFolderType, bool isEnabled);

    }
}