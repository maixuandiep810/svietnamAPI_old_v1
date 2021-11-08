using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using svietnamAPI.Infastructure.Data;
using svietnamAPI.Dtos.Auth;
using svietnamAPI.Repositories.Interfaces.Auth;

namespace svietnamAPI.Repositories.Implements.Auth
{
    public partial class LoginTokenDbRepository : GenericDbRepository, ILoginTokenDbRepository
    {
        public LoginTokenDbRepository(IDataConnectionFactory dataConnectionFactory) : base(dataConnectionFactory)
        {

        }

        public async Task<LoginTokenDto> Get1_Basic_Async(string query, string jwtToken = null)
        {
            var queryParams = new
            {
                JwtToken = jwtToken
            };
            var tokens = await Get1_Entity_Async<LoginTokenDto>(query, queryParams);
            return tokens;
        }


    }
}