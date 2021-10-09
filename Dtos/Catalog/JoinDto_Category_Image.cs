using AutoMapper;
using svietnamAPI.Dtos.StaticFile;
using svietnamAPI.Entities.Catalog;
using svietnamAPI.Entities.StaticFile;

namespace svietnamAPI.Dtos.Catalog
{
    public class JoinDto_Category_Image
    {
        public CategoryDto Category { get; set; }
    }
}