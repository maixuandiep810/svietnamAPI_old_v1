using System.Threading.Tasks;
using svietnamAPI.Dtos.Auth;

namespace svietnamAPI.Repositories.Interfaces.Auth
{
    public interface ILoginTokenDbRepository
    {
        Task<LoginTokenDto> Get1_Basic_Async(string query, string jwtToken = null);
        Task<int> Create1_Async(string query, LoginTokenDto loginToken);
        
    }
}