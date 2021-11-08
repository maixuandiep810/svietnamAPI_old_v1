using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using svietnamAPI.Infastructure.Data;
using svietnamAPI.Dtos.Auth;
using svietnamAPI.Repositories.Interfaces.Auth;

namespace svietnamAPI.Repositories.Implements.Auth
{
    public partial class LoginTokenDbRepository
    {
        public async Task<int> Create1_Async(string query, LoginTokenDto loginToken)
        {
            var id = await Create1_Entity_Async(query, loginToken);
            return id;
        }


    }
}