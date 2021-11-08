using AutoMapper;
using svietnamAPI.Repositories.Interfaces;
using svietnamAPI.Services.Interfaces;
using svietnamAPI.StartupConfiguration.AppSetting;

namespace svietnamAPI.Services.Implements
{
    public abstract class BaseService : IBaseService
    {
        protected readonly IMapper _mapper;
        protected readonly IRepositoryWrapper _repositoryWrapper;
        protected readonly IServiceWrapper _serviceWrapper;


        public BaseService(IMapper mapper, IRepositoryWrapper repositoryWrapper, IServiceWrapper serviceWrapper)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            _serviceWrapper = serviceWrapper;
        }
    }
}