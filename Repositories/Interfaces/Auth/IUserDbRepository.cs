using System.Collections.Generic;
using System.Threading.Tasks;
using svietnamAPI.Dtos.Auth;

namespace svietnamAPI.Repositories.Interfaces.Auth
{
    public interface IUserDbRepository
    {
        Task<IEnumerable<UserDto>> GetN_Basic_Async(string query);
        Task<UserDto> Get1_Basic_Async(string query, int? userId = null, string username = null);
        Task<UserDto> Get1_Group_Async(string query, int? userId = null, string username = null);
    }
}