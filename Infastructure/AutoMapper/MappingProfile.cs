using AutoMapper;
using svietnamAPI.Dtos.AppFile;
using svietnamAPI.Dtos.Catalog;

namespace svietnamAPI.Infastructure.AutoMapper
{
    public partial class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<((string filename, string location, string url) AppFileInfo, string AppFileType, bool IsEnabled), AppFileCreateDto>()
                .ForMember(d => d.Filename, o => o.MapFrom(s => s.AppFileInfo.filename))
                .ForMember(d => d.Location, o => o.MapFrom(s => s.AppFileInfo.location))
                .ForMember(d => d.Url, o => o.MapFrom(s => s.AppFileInfo.url))
                .ForMember(d => d.AppFileType, o => o.MapFrom(s => s.AppFileType))
                .ForMember(d => d.IsEnabled, o => o.MapFrom(s => s.IsEnabled));
            CreateMap<CategoryDto, CategoryUpdateDto>();
            CreateMap<CategoryDto, CategorySimpleResDto>();
            CreateMap<CategoryDto, CategoryDetailResDto>();
            CreateMap<CategoryDto, CategoryTreeResDto>();

            mpEntityPermission();
            mpAuth();
            
        }
    }
}