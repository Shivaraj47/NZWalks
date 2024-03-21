using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Model.Domain;
using NZWalks.API.Model.DTO;
using NZWalks.API.Repository;

namespace NZWalks.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DifficultyController : ControllerBase
	{
		private readonly IDifficultyRepository difficultyRepository;
		private readonly IMapper mapper;

		public DifficultyController(IDifficultyRepository difficultyRepository, IMapper mapper)
		{
			this.difficultyRepository = difficultyRepository;
			this.mapper = mapper;
		}
		/// <summary>
		/// Get walk
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<IActionResult> GetAllAsync()
		{

			//Passing data to repository

			var difficultyDomain = await difficultyRepository.GetAllAsync();


			var difficultyDto = mapper.Map<List<WalksDifficultyDto>>(difficultyDomain);

			return Ok(difficultyDto);
		}

		/// <summary>
		/// create walk 21-03
		/// </summary>
		/// <param name="addDifficultyDTO"></param>
		/// <returns></returns>
		[HttpPost]

		public async Task<IActionResult> CreateAsync([FromBody] AddDifficultyDTO addDifficultyDTO)
		{
			//Convert DTO to Domain Model

			var difficultyDomain = mapper.Map<WalkDifficulty>(addDifficultyDTO);

			//Pass data to respository
			difficultyDomain = await difficultyRepository.CreateAsync(difficultyDomain);

			//Convert Domain model to DTO
			var difficultyDto = mapper.Map<WalksDifficultyDto>(difficultyDomain);

			return Ok(difficultyDto);
		}

		[HttpGet]
		[Route("{id:Guid}")]
		public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
		{
			var difficultyDomain = await difficultyRepository.GetByIdAsync(id);

			if (difficultyDomain == null)
			{
				return NotFound();
			}

			//Convert Domain to DTO
			var difficultyDTO = mapper.Map<WalksDifficultyDto>(difficultyDomain);

			return Ok(difficultyDTO);
		}

		[HttpPut]
		[Route("{id:Guid}")]

		public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateDifficultyDto updateDifficultyDto)
		{
			//Map DTO to Domain model

			var difficultyDomain = mapper.Map<WalkDifficulty>(updateDifficultyDto);

			//Update data using repository

			difficultyDomain = await difficultyRepository.UpdateDiffSync(difficultyDomain, id);

			//Check id exist or not

			if (difficultyDomain == null)
			{
				return NotFound();
			}

			//Convert Domain to DTO

			var difficultyDto = mapper.Map<WalksDifficultyDto>(difficultyDomain);

			return Ok(difficultyDto);

		}

		[HttpDelete]
		[Route("{id:Guid}")]
		public async Task<IActionResult> DeleteAsync(Guid id)
		{
			var difficultyDomain = await difficultyRepository.DeleteAsync(id);

			if (difficultyDomain == null)
			{
				return NotFound();
			}

			//Convert Domain model to DTO

			var difficutlyDto = mapper.Map<WalksDifficultyDto>(difficultyDomain);

			return Ok(difficutlyDto);
		}
	}
}
