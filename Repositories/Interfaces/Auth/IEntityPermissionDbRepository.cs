using System.Collections.Generic;
using System.Threading.Tasks;
using svietnamAPI.Dtos.Auth;

namespace svietnamAPI.Repositories.Interfaces.Auth
{
    public interface IEntityPermissionDbRepository
    {
        Task<EntityPermissionDto> Get1_EP_Async(string entityCode, string actionType, List<string> roleCodes);
        Task<EntityPermissionDto> Get1_EP_OP_Async(string entityCode, string actionType, List<string> roleCodes, int userId);

    }
}