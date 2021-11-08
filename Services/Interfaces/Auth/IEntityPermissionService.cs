using System.Threading.Tasks;
using System.Collections.Generic;
using svietnamAPI.Dtos.Catalog;
using Microsoft.AspNetCore.Http;
using svietnamAPI.Dtos.ValueDtos;
using svietnamAPI.Dtos.Auth;

namespace svietnamAPI.Services.Interfaces.AppFile
{
    public interface IEntityPermissionService : IBaseService
    {
        Task<EntityPermissionDto> Get1_EP_Async(string entityCode, string actionType, List<string> roleCodes);
        Task<EntityPermissionDto> Get1_EP_OP_Async(string entityCode, string actionType, List<string> roleCodes, int userId);

    }
}