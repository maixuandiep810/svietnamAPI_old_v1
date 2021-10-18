using System.Net.NetworkInformation;
using System.IO;
using System;
using svietnamAPI.Services.Interfaces.Catalog;
using svietnamAPI.Repositories.Interfaces.Catalog;
using System.Threading.Tasks;
using System.Collections.Generic;
using svietnamAPI.Dtos.Catalog;
using AutoMapper;
using System.Linq;
using svietnamAPI.Repositories;
using svietnamAPI.Repositories.Interfaces;
using svietnamAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using svietnamAPI.Dtos.ValueDtos;
using svietnamAPI.Dtos.AppFile;

namespace svietnamAPI.Services.Implements.AppFile
{
    public partial class AppFileService
    {
        public async Task<(string location, string url, string filename)> SaveFormFileAsync(IFormFile formFile, int folderType) {
            var fullFilename = ContentDispositionHeaderValue.Parse(formFile.ContentDisposition).FileName.Trim('"'); // Delete "" in Content-Disposition
            var filename = Path.GetFileNameWithoutExtension(fullFilename);
            var fileExtension = Path.GetExtension(fullFilename);
            var sourceStream = formFile.OpenReadStream();
            var appFileInfo = await _repositoryWrapper.PhysicalFileRepo.WriteAppFileAsync(folderType, sourceStream, fileExtension, filename);
            return appFileInfo;
        }

        public async Task<int> SaveAppFileAsync(IFormFile formFile, string appFileType, int physicalFolderType, bool isEnabled) {
            var appFileInfo = await SaveFormFileAsync(formFile, physicalFolderType);
            var createAppFile = _mapper.Map<CreateAppFileDto>((appFileInfo, appFileType, isEnabled));
            var insertedId = await _repositoryWrapper.AppFileDbRepo.CreateAppFileAsync(createAppFile);
            return insertedId;
        }


    }
}