using svietnamAPI.Dtos.ApiResponse;
using Microsoft.AspNetCore.Mvc;

namespace svietnamAPI.Helper.Extensions
{
    public static class JsonResultExtension
    {
        public static void SetErrorResult(this JsonResult jsonResult, int responseCode, string message, string stackTrace = null, string exceptionMessage = null)
        {
            var resBody = new ErrorResponse
            {
                Code = responseCode,
                Message = message
            };
            jsonResult.Value = resBody;
        }
    }
}