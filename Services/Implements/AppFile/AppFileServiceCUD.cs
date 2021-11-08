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
using svietnamAPI.Repositories.Implements.AppFile;

namespace svietnamAPI.Services.Implements.AppFile
{
    public partial class AppFileService
    {
        public async Task<(string location, string url, string filename)> SaveFormFileAsync(IFormFile formFile, PhysicalFolderType pscFolderType) {
            var fullFilename = ContentDispositionHeaderValue.Parse(formFile.ContentDisposition).FileName.Trim('"'); // Delete "" in Content-Disposition
            var filename = Path.GetFileNameWithoutExtension(fullFilename);
            var fileExtension = Path.GetExtension(fullFilename);
            var sourceStream = formFile.OpenReadStream();
            var appFileInfo = await _repositoryWrapper.PhysicalFileRepo.WriteAppFileAsync(pscFolderType, sourceStream, fileExtension, filename);
            return appFileInfo;
        }

        public async Task<int> SaveAppFileAsync(IFormFile formFile, AppFileType appFileType, PhysicalFolderType pscFolderType, bool isEnabled) {
            var appFileInfo = await SaveFormFileAsync(formFile, pscFolderType);
            var createAppFile = _mapper.Map<AppFileCreateDto>((appFileInfo, appFileType, isEnabled));
            var insertedId = await _repositoryWrapper.AppFileDbRepo.Create1_Async(AppFileDbQuery.Create1, createAppFile);
            return insertedId;
        }


    }
}