using svietnamAPI.Services.Interfaces.Catalog;
using svietnamAPI.Repositories.Interfaces.Catalog;
using System.Threading.Tasks;
using System.Collections.Generic;
using svietnamAPI.Dtos.Catalog;
using AutoMapper;
using System.Linq;
using Microsoft.AspNetCore.Http;
using svietnamAPI.Dtos.ValueDtos;

namespace svietnamAPI.Services.Implements.Catalog
{
    public partial class CategoryService
    {
        public async Task<bool> UpdateCategoryBaseImageAsync(int categoryId, IFormFile formFile)
        {
            var category = await _repositoryWrapper.CategoryDbRepo.GetCategoryByIdAsync(categoryId);
            if (category == null)
                return false;
            var updateCategory = _mapper.Map<UpdateCategoryDto>(category);
            var appFileId = await _serviceWrapper.AppFileService.SaveAppFileAsync(formFile, AppFileType.Image, PhysicalFolderType.CategoryImage, true);
            if (appFileId == 0)
                return false;
            updateCategory.BaseImageId = appFileId; 
            await _repositoryWrapper.CategoryDbRepo.UpdateCategoyAsync(updateCategory);
            return true;
        }


    }
}