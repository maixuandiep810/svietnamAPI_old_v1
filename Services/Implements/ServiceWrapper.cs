using AutoMapper;
using svietnamAPI.Repositories.Interfaces;
using svietnamAPI.Services.Implements.Catalog;
using svietnamAPI.Services.Interfaces;
using svietnamAPI.Services.Interfaces.Catalog;
using svietnamAPI.Services.Implements.AppFile;
using svietnamAPI.Services.Interfaces.AppFile;
using svietnamAPI.StartupConfiguration.AppSetting;

namespace svietnamAPI.Services.Implements
{
    public class ServiceWrapper : IServiceWrapper
    {
        protected readonly ServerSetting _serverSetting;
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private ICategoryService _categoryServices;
        private IAppFileService _appFileService;
        private ILoginTokenService _loginTokenService;
        private IEntityPermissionService _entityPermissionService;
        private IUserService _userService;

        public ServiceWrapper(ServerSetting serverSetting, IMapper mapper, IRepositoryWrapper repositoryWrapper)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
        }

        public ICategoryService CategoryService
        {
            get
            {
                if (_categoryServices == null)
                {
                    _categoryServices = new CategoryService(_mapper, _repositoryWrapper, this);
                }
                return _categoryServices;
            }
        }
        public IAppFileService AppFileService
        {
            get
            {
                if (_appFileService == null)
                {
                    _appFileService = new AppFileService(_mapper, _repositoryWrapper, this);
                }
                return _appFileService;
            }
        }
        public ILoginTokenService LoginTokenService
        {
            get
            {
                if (_loginTokenService == null)
                {
                    _loginTokenService = new LoginTokenService(_serverSetting, _mapper, _repositoryWrapper, this);
                }
                return _loginTokenService;
            }
        }
        public IEntityPermissionService EntityPermissionService
        {
            get
            {
                if (_entityPermissionService == null)
                {
                    _entityPermissionService = new EntityPermissionService(_mapper, _repositoryWrapper, this);
                }
                return _entityPermissionService;
            }
        }
        public IUserService UserService
        {
            get
            {
                if (_userService == null)
                {
                    _userService = new UserService(_mapper, _repositoryWrapper, this);
                }
                return _userService;
            }
        }


    }
}