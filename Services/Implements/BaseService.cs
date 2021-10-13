using AutoMapper;
using svietnamAPI.Repositories.Interfaces;
using svietnamAPI.Services.Interfaces;

namespace svietnamAPI.Services.Implements
{
    public abstract class BaseService : IBaseService
    {
        protected readonly IMapper _mapper;
        protected readonly IRepositoryWrapper _repositoryWrapper;

        public BaseService(IMapper mapper, IRepositoryWrapper repositoryWrapper)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
        }
    }
}