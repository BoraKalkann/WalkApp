using AutoMapper;
using WalkApp.Models;
using WalkApp.Models.DTO;
namespace WalkApp.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region, RegionDTO>().ReverseMap();
            CreateMap<AddRequestRegionDTO, Region>().ReverseMap();
            CreateMap<UpdateRequestDto, Region>().ReverseMap();
            CreateMap<AddWalkRequestDTO, Walk>().ReverseMap();
            CreateMap<Walk, WalkDTO>().ReverseMap();
            CreateMap<Difficulty, DifficultyDTO>().ReverseMap();

        }
    }
}
