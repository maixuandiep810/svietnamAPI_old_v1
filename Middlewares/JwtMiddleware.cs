// using System.Security.Claims;
// using System.Threading.Tasks;
// using svietnamAPI.StartupConfiguration.AppSetting;
// using svietnamAPI.Services.Interfaces;
// using svietnamAPI.Helper;
// using Microsoft.AspNetCore.Http;
// using Microsoft.Extensions.Options;
// using System.Linq;
// using svietnamAPI.Helper.Extensions;
// using svietnamAPI.Dtos.ApiResponse;
// using svietnamAPI.Dtos.Auth;
// using svietnamAPI.Dtos.ValueDtos;
// using System;

// namespace svietnamAPI.Middlewares
// {
//     public class JwtMiddleware
//     {
//         private readonly RequestDelegate _next;
//         private readonly JwtSetting _jwtSetting;
//         private readonly IJwtService _jwtService;
//         private readonly IUserService _userService;

//         public JwtMiddleware(RequestDelegate next, IOptions<JwtSetting> jwtSetting, IJwtService jwtService, IUserService userService)
//         {
//             _next = next;
//             _jwtSetting = jwtSetting.Value;
//             _jwtService = jwtService;
//             _userService = userService;
//         }

//         public async Task Invoke(HttpContext context, IUserService userService)
//         {
//             var loginToken = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

//             if (loginToken != null)
//             {
//                 var isValidLoginToken = await _jwtService.IsValidJwtToken(loginToken);
//                 if (isValidLoginToken == false)
//                 {
//                     await context.Response.WriteErrorResponseAsync(StatusCodes.Status401Unauthorized, 1001, ApiConst.E1001);
//                     return;
//                 }
//                 context.User = JwtHelper.ValidateJwtToken(loginToken, _jwtSetting);
//             }
//             else
//             {
//                 var roles = await _userService.GetRolesAsync(AuthValueConst.NullUserId, AuthValueConst.GuestGroupCode);
//                 var roleCodes = roles.ToList().Select(p => p.Code);
//                 context.User = new ClaimsPrincipal(new ClaimsIdentity(new[] {
//                     new Claim(ClaimInfo.GroupCode, AuthValueConst.GuestGroupCode),
//                     new Claim(ClaimInfo.RoleCodes, String.Join(AuthValueConst.RoleCodesSeperator,roleCodes))
//                 }));
//             }

//             await _next(context);
//         }
//     }
// }