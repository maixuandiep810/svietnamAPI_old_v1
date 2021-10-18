using AutoMapper;
using svietnamAPI.Repositories.Interfaces;
using svietnamAPI.Services.Implements.Catalog;
using svietnamAPI.Services.Interfaces;
using svietnamAPI.Services.Interfaces.Catalog;
using svietnamAPI.Services.Implements.AppFile;
using svietnamAPI.Services.Interfaces.AppFile;

namespace svietnamAPI.Services.Implements
{
    public class ServiceWrapper : IServiceWrapper
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private ICategoryService _categoryServices;
        private IAppFileService _appFileService;

        public ServiceWrapper(IMapper mapper, IRepositoryWrapper repositoryWrapper)
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


    }
}