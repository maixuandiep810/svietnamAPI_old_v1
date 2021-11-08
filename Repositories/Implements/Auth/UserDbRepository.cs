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
    public partial class UserDbRepository : GenericDbRepository, IUserDbRepository
    {
        public UserDbRepository(IDataConnectionFactory dataConnectionFactory) : base(dataConnectionFactory)
        {

        }

        public async Task<IEnumerable<UserDto>> GetN_Basic_Async(string query)
        {
            var queryParams = new
            {

            };
            var users = await GetN_Entity_Async<UserDto>(query, queryParams);
            return users;
        }

        public async Task<UserDto> Get1_Basic_Async(string query, int? userId = null, string username = null)
        {
            var queryParams = new
            {
                UserId = userId,
                Username = username
            };
            var user = await Get1_Entity_Async<UserDto>(query, queryParams);
            return user;
        }

        public async Task<UserDto> Get1_Group_Async(string query, int? userId = null, string username = null)
        {
            var queryParams = new
            {
                UserId = userId,
                Username = username
            };
            var users = await GetN_Group_Async(query, queryParams);
            return users?.FirstOrDefault();
        }

        private async Task<IEnumerable<UserDto>> GetN_Group_Async(string query, object queryParams)
        {
            var users = await WithConnection<IEnumerable<UserDto>>(
            async dbConnection =>
            {
                var records = await dbConnection.QueryAsync<UserDto, GroupDto, UserDto>(
                query,
                (user, group) =>
                {
                    user.Group = group;
                    return user;
                },
                queryParams,
                splitOn: "GroupId"
                );
                return records;
            }
            );
            return users;
        }



    }
}