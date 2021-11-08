using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using svietnamAPI.Infastructure.Data;
using svietnamAPI.Dtos.Auth;
using svietnamAPI.Repositories.Interfaces.Auth;

namespace svietnamAPI.Repositories.Implements.Auth
{
    public partial class EndpointDbRepository : GenericDbRepository, IEndpointDbRepository
    {
        public EndpointDbRepository(IDataConnectionFactory dataConnectionFactory) : base(dataConnectionFactory)
        {

        }

        public async Task<EndpointDto> Get1_Role_Async(string query, string endpointId = null, string endpointCode = null, List<string> roleCodes = null)
        {
            var queryParams = new
            {
                EndpointId = endpointId,
                EndpointCode = endpointCode,
                RoleCodes = roleCodes
            };
            var endpoints = await GetN_Role_Async(query, queryParams);
            return endpoints?.FirstOrDefault();
        }




        private async Task<IEnumerable<EndpointDto>> GetN_Role_Async(string query, object queryParams)
        {
            var endpoints = await WithConnection<IEnumerable<EndpointDto>, IEnumerable<EndpointDto>>(
                async dbConnection =>
                {
                    var records = await dbConnection.QueryAsync<EndpointDto, RoleToEndpointDto, RoleDto, EndpointDto>(
                    query, (endpoint, rte, role) =>
                    {
                        endpoint.Roles = new List<RoleDto>();
                        endpoint.Roles.Add(role);
                        return endpoint;
                    },
                    queryParams,
                    splitOn: "RoleToEndpointId, RoleId"
                    );
                    return records;
                },
                endpoints =>
                {
                    if (endpoints == null || endpoints.Count() == 0)
                        return null;
                    endpoints = endpoints.GroupBy(p => p.Roles[0].RoleId).Select(
                        g =>
                        {
                            var groupbyEndpoint = g.First();
                            groupbyEndpoint.Roles = g.Select(p => p.Roles[0]).ToList();
                            return groupbyEndpoint;
                        }
                    );
                    return endpoints;
                }
            );
            return endpoints;
        }



    }
}