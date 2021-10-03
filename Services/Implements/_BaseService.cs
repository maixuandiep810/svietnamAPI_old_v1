using AutoMapper;
using svietnamAPI.Services.Interfaces;

namespace svietnamAPI.Services.Implements
{
    public abstract class BaseService : IBaseService
    {
        protected readonly IMapper _mapper;

        public BaseService(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}