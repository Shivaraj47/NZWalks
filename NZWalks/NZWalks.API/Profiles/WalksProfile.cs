using AutoMapper;
using NZWalks.API.Model.Domain;
using NZWalks.API.Model.DTO;

namespace NZWalks.API.Profiles
{
	public class WalksProfile : Profile
	{
		public WalksProfile()
		{
			CreateMap<Walk, WalkDto>().ReverseMap();
			CreateMap<WalkDifficulty, WalksDifficultyDto>().ReverseMap();
			CreateMap<AddWalkRequestDTO, Walk>().ReverseMap();
			CreateMap<UpdateWalkRequestDto, Walk>().ReverseMap();
			CreateMap<WalksDifficultyDto, WalkDifficulty>().ReverseMap();
			CreateMap<AddDifficultyDTO, WalkDifficulty>().ReverseMap();
			CreateMap<UpdateDifficultyDto, WalkDifficulty>().ReverseMap();
		}

	}
}
