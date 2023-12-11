using AutoMapper;
using NZWalks.API.Model.Domain;
using NZWalks.API.Model.DTO;

namespace NZWalks.API.Profiles
{
    public class RegionProfile: Profile
    {
        public RegionProfile()
        {
            CreateMap<Model.Domain.Region, Model.DTO.RegionDto>().ReverseMap();
            CreateMap<AddRegionRequestDto , Model.Domain.Region>().ReverseMap();
        }
    }
}
