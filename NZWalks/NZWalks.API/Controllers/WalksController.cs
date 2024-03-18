using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Model.Domain;
using NZWalks.API.Model.DTO;
using NZWalks.API.Repository;

namespace NZWalks.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WalksController : ControllerBase
	{
		private readonly IRegionRepository regionRepository;
		private readonly IWalkRepository walkRepository;
		private readonly IMapper mapper;


		public WalksController(IWalkRepository walkRepository, IMapper mapper)
		{
			this.walkRepository = walkRepository;
			this.mapper = mapper;
		}
		[HttpGet]
		[Authorize(Roles = "reader")]
		public async Task<IActionResult> GetALlAsync()
		{
			//Getting data from database
			var walkdomain = await walkRepository.GetAllWalksAsync();

			//convert Domain to DTO
			var walkDto = mapper.Map<List<WalkDto>>(walkdomain);

			return Ok(walkDto);


		}

		[HttpGet]
		[Route("{id:Guid}")]
		[Authorize(Roles = "reader")]
		public async Task<IActionResult> GetWalkByIdAsync(Guid id)

		{
			//Getting data from domain
			var walkDomain = await walkRepository.GetWalkByIdAsync(id);

			//convert Domain to DTO
			var walkDto = mapper.Map<WalkDto>(walkDomain);
			return Ok(walkDto);
		}

		[HttpPost]
		[Authorize(Roles = "writer")]
		public async Task<IActionResult> CreateWalkAsync([FromBody] AddWalkRequestDTO addWalkRequestDTO)
		{
			//Convert DTO to Domainmodel
			var walkDomain = mapper.Map<Walk>(addWalkRequestDTO);


			// Pass details to repository

			walkDomain = await walkRepository.CreateWalkAsync(walkDomain);

			//Convert Domain model to DTO 
			//Making sure you use DTO

			var walkDto = mapper.Map<WalkDto>(walkDomain);

			return Ok(walkDto);
		}

		[HttpPut]
		[Route("{id:Guid}")]
		[Authorize(Roles = "writer")]

		public async Task<IActionResult> UpdateWalkAsync([FromRoute] Guid id, [FromBody] UpdateWalkRequestDto updateWalkRequest)
		{
			//convert DTO to Domain Model

			var walkdomain = mapper.Map<Walk>(updateWalkRequest);

			//Update Walk using repository

			walkdomain = await walkRepository.UpdateWalkAsync(id, walkdomain);

			if (walkdomain == null)
			{
				return NotFound(id);
			}

			//Convert Domain to DTO
			var walkDto = mapper.Map<WalkDto>(walkdomain);
			return Ok(walkDto);
		}

		[HttpDelete]
		[Route("{id:Guid}")]
		[Authorize(Roles = "writer")]

		public async Task<IActionResult> DeleteWalkAsync([FromRoute] Guid id)
		{
			var walksDomain = await walkRepository.DeleteWalkAsync(id);

			//check the id is exist or not
			if (walkRepository == null)
			{
				return NotFound();
			}

			//Convert Domain mode to DTO

			var walkDto = mapper.Map<WalkDto>(walksDomain);
			return Ok(walkDto);
		}
	}
}
