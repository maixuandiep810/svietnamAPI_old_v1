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
    public partial class EntityPermissionService : BaseService, IEntityPermissionService
    {
        public EntityPermissionService(IMapper mapper, IRepositoryWrapper repositoryWrapper, IServiceWrapper serviceWrapper)
            : base(mapper, repositoryWrapper, serviceWrapper)
        {
        }

        public async Task<EntityPermissionDto> Get1_EP_Async(string entityCode, string actionType, List<string> roleCodes)
        {
            return await _repositoryWrapper.EntityPermissionDbRepo.Get1_EP_Async(entityCode, actionType, roleCodes);
        }

        public async Task<EntityPermissionDto> Get1_EP_OP_Async(string entityCode, string actionType, List<string> roleCodes, int userId)
        {
            return await _repositoryWrapper.EntityPermissionDbRepo.Get1_EP_OP_Async(entityCode, actionType, roleCodes, userId);
        }
    }
}