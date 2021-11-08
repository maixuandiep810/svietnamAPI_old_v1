using System.Net.NetworkInformation;
using System.IO;
using System;
using svietnamAPI.Services.Interfaces.Catalog;
using svietnamAPI.Repositories.Interfaces.Catalog;
using System.Threading.Tasks;
using System.Collections.Generic;
using svietnamAPI.Dtos.Catalog;
using AutoMapper;
using System.Linq;
using svietnamAPI.Repositories;
using svietnamAPI.Repositories.Interfaces;
using svietnamAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using svietnamAPI.Dtos.ValueDtos;
using svietnamAPI.Dtos.AppFile;
using svietnamAPI.Services.Interfaces.AppFile;
using svietnamAPI.Dtos.Auth;
using svietnamAPI.Repositories.Implements.Auth;
using svietnamAPI.Helper;
using svietnamAPI.StartupConfiguration.AppSetting;

namespace svietnamAPI.Services.Implements.AppFile
{
    public partial class LoginTokenService : BaseService, ILoginTokenService
    {
        protected readonly ServerSetting _serverSetting;

        public LoginTokenService(ServerSetting serverSetting, IMapper mapper, IRepositoryWrapper repositoryWrapper, IServiceWrapper serviceWrapper)
            : base(mapper, repositoryWrapper, serviceWrapper)
        {
            _serverSetting = serverSetting;
        }

        public async Task<string> CreateLoginTokenAsync(UserDto user) {
            var jwtToken = GenerateJwtToken(user);
            var loginToken = new LoginTokenDto {
                JwtToken = jwtToken
            };
            await _repositoryWrapper.LoginTokenDbRepo.Create1_Async(LoginTokenDbQuery.Create1, loginToken);
            return jwtToken;
        }
        private string GenerateJwtToken(UserDto user)
        {
            var jwtToken = JwtHelper.GenerateJwtToken(user, _serverSetting);
            return jwtToken;
        }


    }
}