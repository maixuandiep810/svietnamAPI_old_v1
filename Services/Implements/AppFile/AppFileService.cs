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

namespace svietnamAPI.Services.Implements.AppFile
{
    public partial class AppFileService : BaseService, IAppFileService
    {
        public AppFileService(IMapper mapper, IRepositoryWrapper repositoryWrapper, IServiceWrapper serviceWrapper)
            : base(mapper, repositoryWrapper, serviceWrapper)
        {
        }


    }
}