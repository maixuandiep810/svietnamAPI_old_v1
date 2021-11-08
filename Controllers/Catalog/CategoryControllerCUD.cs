// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
// using svietnamAPI.Dtos.ApiResponse;
// using svietnamAPI.Dtos.ValueDtos;

// namespace svietnamAPI.Controllers.Catalog
// {
//     public partial class CategoryController
//     {
//         [HttpPost("{categoryId}/update-base-image"), DisableRequestSizeLimit]
//         public async Task<IActionResult> UpdateCategoryBaseImageAsync(int categoryId, [FromForm] IFormFile formFile)
//         {
//             var isUpdateSuccess = await _serviceWrapper.CategoryService.UpdateCategoryBaseImageAsync(categoryId, formFile);
//             if (isUpdateSuccess == false)
//             {
//                 var errorApi = new ErrorResponse {
//                     Code = 12001,
//                     Message = ResponseCode.E12001
//                 };
//                 return Ok(errorApi);
//             }
//             var successApi = new SuccessResponse<bool> {
//                 Code = 62001,
//                 Data = isUpdateSuccess,
//                 Message = ResponseCode.S62001
//             };
//             return Ok(successApi);
//         }


//     }
// }