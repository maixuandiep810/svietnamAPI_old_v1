using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using svietnamAPI.Repositories.Interfaces;
using svietnamAPI.Services.Interfaces.Catalog;

namespace svietnamAPI.Controllers.Catalog
{

    [Route("categories")]
    [ApiController]
    public class CategoryController : SVNBaseController
    {
        public CategoryController(IRepositoryWrapper repositoryWrapper) : base (repositoryWrapper)
        {
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            var categories = await _repositoryWrapper.CategoryRepo.GetCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("getall-image")]
        public async Task<IActionResult> GetCategories_Image_Async()
        {
            var categories = await _repositoryWrapper.CategoryRepo.GetCategories_Image_Async();
            return Ok(categories);
        }

        // [HttpGet("getbyid-image/{categoryId}")]
        // public async Task<IActionResult> GetCategoryById_Image_Async(int categoryId)
        // {
        //     var category = await _categoryService.GetCategoryById_Image_Async(categoryId);
        //     return Ok(category);
        // }
    }
}