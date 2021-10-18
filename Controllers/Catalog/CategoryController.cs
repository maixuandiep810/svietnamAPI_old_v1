using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using svietnamAPI.Services.Interfaces;

namespace svietnamAPI.Controllers.Catalog
{

    [Route("categories")]
    [ApiController]
    public partial class CategoryController : AppBaseController
    {
        public CategoryController(IServiceWrapper serviceWrapper) : base(serviceWrapper)
        {
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            var categories = await _serviceWrapper.CategoryService.GetCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("getall-detail")]
        public async Task<IActionResult> GetCategories_Image_Async()
        {
            var categories = await _serviceWrapper.CategoryService.GetCategories_Image_Async();
            return Ok(categories);
        }

        [HttpGet("{categoryId}/get")]
        public async Task<IActionResult> GetCategoryByIdAsync(int categoryId)
        {
            var category = await _serviceWrapper.CategoryService.GetCategoryByIdAsync(categoryId);
            return Ok(category);
        }

        [HttpGet("{categoryId}/get-detail")]
        public async Task<IActionResult> GetCategory_Image_Async(int categoryId)
        {
            var category = await _serviceWrapper.CategoryService.GetCategoryById_Image_Async(categoryId);
            return Ok(category);
        }


    }
}