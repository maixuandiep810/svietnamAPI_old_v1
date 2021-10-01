using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using svietnamAPI.Services.Interfaces.Catalog;

namespace svietnamAPI.Controllers.Catalog
{

    [Route("categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            var users = await _categoryService.GetCategoriesAsync();
            return Ok(users);
        }
    }
}