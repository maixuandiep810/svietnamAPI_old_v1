using System.Collections.Generic;
using System.Threading.Tasks;
using svietnamAPI.Dtos.Auth;

namespace svietnamAPI.Repositories.Interfaces.Auth
{
    public interface IEndpointDbRepository
    {
        Task<EndpointDto> Get1_Role_Async(string query, string endpointId = null, string endpointCode = null, List<string> roleCodes = null);

    }
}