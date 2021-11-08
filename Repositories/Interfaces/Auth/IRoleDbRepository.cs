using System.Collections.Generic;
using System.Threading.Tasks;
using svietnamAPI.Dtos.Auth;

namespace svietnamAPI.Repositories.Interfaces.Auth
{
    public interface IRoleDbRepository
    {
        Task<IEnumerable<RoleDto>> GetN_Basic_Async(string query, int? userId = null, string groupCode = null);
    }
}