using AutoMapper;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Model.Domain;
using NZWalks.API.Model.DTO;
using NZWalks.API.Repository;
using System.Diagnostics.Contracts;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRegion()
        {
           var regions = await regionRepository.GetAllRegionAsync();

           var regionsDTO = mapper.Map<List<Model.DTO.RegionDto>>(regions);
            return Ok(regionsDTO);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [ActionName("GetByIDAsync")]
        public async Task<IActionResult> GetByIDAsync(Guid id)
        {
           var regionDomain = await regionRepository.GetByIdAsync(id);

            if(regionDomain == null)
            {
                return NotFound();
            }

            //Map Domain model to DTO 

            var regionDTO = mapper.Map<Model.DTO.RegionDto>(regionDomain);

            return Ok(regionDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddRegionAsync(AddRegionRequestDto addRegionRequestDto)
        {
            //Convert DTO to domain model

            var region = new Region()
            {
                Code = addRegionRequestDto.Code,
                Area = addRegionRequestDto.Area,
                Lat = addRegionRequestDto.Lat,
                Long = addRegionRequestDto.Long,
                Name = addRegionRequestDto.Name,
                Population = addRegionRequestDto.Population
            };

          // Pass details to repository

          region = await regionRepository.AddRegionAsync(region);

            //Convert Domain mode to DTO

            var regionDTO = new RegionDto
            {
                Id = region.Id,
                Code = region.Code,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Name = region.Name,
                Population = region.Population
            };

            return CreatedAtAction(nameof(GetByIDAsync), new { id = regionDTO.Id }, regionDTO);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var region =  await regionRepository.DeleteAsync(id);

            if(region == null)
            {
                return NotFound();
            }

            var regionDTO = new RegionDto
            {
                Id = region.Id,
                Code = region.Code,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Name = region.Name,
                Population = region.Population
            };
            return Ok(regionDTO);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateRegionASync([FromRoute] Guid id, [FromBody] UpdateRegionRequest updateRegionRequest)
        {

            //Convetr DTO to Domain model

            var region = new Region()
            {
                Code = updateRegionRequest.Code,
                Area = updateRegionRequest.Area,
                Lat = updateRegionRequest.Lat,
                Long = updateRegionRequest.Long,
                Name = updateRegionRequest.Name,
                Population = updateRegionRequest.Population
            };

            //Update region using repository

            region = await regionRepository.UpdateRegionAsync(region, id);

            if(region == null)
            {
                return NotFound();
            }

            //Convert Domain to DTO

            var regionDTO = new RegionDto
            {
                Id = region.Id,
                Code = region.Code,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Name = region.Name,
                Population = region.Population
            };

            return Ok(regionDTO);
        }
    }
}
