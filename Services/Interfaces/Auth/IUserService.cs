using System.Threading.Tasks;
using System.Collections.Generic;
using svietnamAPI.Dtos.Catalog;
using Microsoft.AspNetCore.Http;
using svietnamAPI.Dtos.ValueDtos;
using svietnamAPI.Dtos.Auth;

namespace svietnamAPI.Services.Interfaces.AppFile
{
    public interface IUserService : IBaseService
    {
        Task<IEnumerable<UserDto>> GetN_Basic_Async(HttpContextEntityPermission httpEP);
        Task<UserDto> Get1_ById_Basic_Async(HttpContextEntityPermission httpEP, int userId);
        Task<UserDto> Get1_ById_Group_Async(HttpContextEntityPermission httpEP, int userId);

    }
}