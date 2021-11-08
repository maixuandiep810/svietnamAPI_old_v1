using System.Threading.Tasks;
using System.Collections.Generic;
using svietnamAPI.Dtos.Catalog;
using Microsoft.AspNetCore.Http;
using svietnamAPI.Dtos.ValueDtos;

namespace svietnamAPI.Services.Interfaces.AppFile
{
    public interface IAppFileService : IBaseService
    {
        Task<int> SaveAppFileAsync(IFormFile formFile, AppFileType appFileType, PhysicalFolderType pscFolderType, bool isEnabled);

    }
}