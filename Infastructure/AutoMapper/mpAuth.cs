using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using svietnamAPI.Dtos.Auth;

namespace svietnamAPI.Infastructure.AutoMapper
{
    public partial class MappingProfile : Profile
    {
        public void mpAuth()
        {
            CreateMap<UserDto, LoggedInUserDto>()
                .ForMember(d => d.LoginToken, o => o.Ignore())
                .ForMember(d => d.RoleCodes, o => o.Ignore());  
        }
    }
}