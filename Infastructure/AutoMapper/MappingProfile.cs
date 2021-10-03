using AutoMapper;
using svietnamAPI.Entities.Catalog;
using svietnamAPI.Dtos.Catalog;

namespace svietnamAPI.Infastructure.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // VD
            // // Thuộc tính FullName trong UserViewModel được kết hợp từ FirstName và LastName trong User
            // CreateMap<User, UserViewModel>().ForMember(d => d.FullName, o => o.MapFrom(s => $"{s.FirstName}   {s.LastName}"));
            // CreateMap<UserViewModel, User>();
            // CreateMap<RegisterUserDto, PasswordDto, UserDto>();

            CreateMap<CategoryEntity, CategoryDto>()
                .ForMember(d => d.Images, opt => opt.Ignore());
        }
    }
}