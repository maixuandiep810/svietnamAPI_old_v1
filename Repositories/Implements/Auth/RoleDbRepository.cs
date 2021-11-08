using System.Reflection.Metadata;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using svietnamAPI.Infastructure.Data;
using svietnamAPI.Dtos.Auth;
using svietnamAPI.Repositories.Interfaces;
using svietnamAPI.Repositories.Interfaces.Auth;

namespace svietnamAPI.Repositories.Implements.Auth
{
    public partial class RoleDbRepository : GenericDbRepository, IRoleDbRepository
    {
        public RoleDbRepository(IDataConnectionFactory dataConnectionFactory) : base(dataConnectionFactory)
        {

        }

        public async Task<IEnumerable<RoleDto>> GetN_Basic_Async(string query, int? userId = null, string groupCode = null)
        {
            var queryParams = new
            {
                UserId = userId,
                GroupCode = groupCode
            };
            var roles = await GetN_Entity_Async<RoleDto>(query, queryParams);
            return roles?.Distinct();
        }



    }
}