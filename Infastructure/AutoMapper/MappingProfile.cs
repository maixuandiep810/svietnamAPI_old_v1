using AutoMapper;
using svietnamAPI.Dtos.AppFile;
using svietnamAPI.Dtos.Catalog;

namespace svietnamAPI.Infastructure.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<((string filename, string location, string url) AppFileInfo, string AppFileType, bool IsEnabled), CreateAppFileDto>()
                .ForMember(d => d.Filename, o => o.MapFrom(s => s.AppFileInfo.filename))
                .ForMember(d => d.Location, o => o.MapFrom(s => s.AppFileInfo.location))
                .ForMember(d => d.Url, o => o.MapFrom(s => s.AppFileInfo.url))
                .ForMember(d => d.AppFileType, o => o.MapFrom(s => s.AppFileType))
                .ForMember(d => d.IsEnabled, o => o.MapFrom(s => s.IsEnabled));
            CreateMap<CategoryDto, UpdateCategoryDto>();
        }
    }
}