using AutoMapper;
using svietnamAPI.Entities.Catalog;
using svietnamAPI.Dtos.Catalog;
using svietnamAPI.Entities.StaticFile;
using svietnamAPI.Dtos.StaticFile;

namespace svietnamAPI.Infastructure.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryEntity, CategoryDto>()
                .ForMember(d => d.BaseImage, opt => opt.Ignore())
                .ForMember(d => d.ThumbnailImage, opt => opt.Ignore());

            CreateMap<JoinEntity_Category_Image, JoinDto_Category_Image>()
                .ForMember(d => d.Category, o => o.MapFrom(s => s.Category))
                .ForPath(d => d.Category.BaseImage, o => o.MapFrom(s => s.BaseImage))
                .ForPath(d => d.Category.ThumbnailImage, o => o.MapFrom(s => s.ThumbnailImage));

            CreateMap<ImageEntity, ImageDto>();
        }
    }
}