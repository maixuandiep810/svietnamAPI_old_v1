using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using svietnamAPI.Dtos.ApiResponse;

namespace svietnamAPI.Controllers.Catalog
{
    public partial class CategoryController
    {
        [HttpPost("{categoryId}/update-base-image"), DisableRequestSizeLimit]
        public async Task<IActionResult> UpdateCategoryBaseImageAsync(int categoryId, [FromForm] IFormFile formFile)
        {
            var isUpdateSuccess = await _serviceWrapper.CategoryService.UpdateCategoryBaseImageAsync(categoryId, formFile);
            if (isUpdateSuccess == false)
            {
                var errorApi = new ErrorApi {
                    Code = 12001,
                    Message = ApiConst.E12001
                };
                return Ok(errorApi);
            }
            var successApi = new SuccessApi<bool> {
                Code = 62001,
                Data = isUpdateSuccess,
                Message = ApiConst.S62001
            };
            return Ok(successApi);
        }


    }
}