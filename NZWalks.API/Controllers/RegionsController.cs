using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDBContext dbContext;
        private readonly IRegionsRepositories regionsRepositories;
        private readonly IMapper mapper;
        public RegionsController(NZWalksDBContext dbContext, IRegionsRepositories regionsRepositories, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionsRepositories = regionsRepositories;
            this.mapper = mapper;
        }
        //GET:https://localhost
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //get data from the DB
            var regions = await regionsRepositories.GetAllAsync();

            //map data from domain models to DTOs
            var regionDTO = mapper.Map<List<RegionDTO>>(regions);
            
            //returning DTOs
            return Ok(regionDTO);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {

            //var region = dbContext.Regions.Find(id); --> only for primary key
            //get region domain model from the database
            var regionDomain = await regionsRepositories.GetByIdAsync(id);

            if (regionDomain == null)
            {
                return NotFound();
            }

            //map data from domain model to DTOs
            var regionsDTO = mapper.Map<RegionDTO>(regionDomain);
               

            return Ok(regionsDTO);
        }
        
        //For creating new regions
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] RegionRequestDTO regionRequestDTO)
        {
            
                //convert DTO to domain model
                var regionDomainModel = mapper.Map<Region>(regionRequestDTO);

                //Create a new Region
                regionDomainModel = await regionsRepositories.CreateAsync(regionDomainModel);
                
                //Creating new DTO to return to the client
                var regionDTO = mapper.Map<RegionDTO>(regionDomainModel);

                return CreatedAtAction(nameof(GetById), new { id = regionDTO.Id }, regionDTO);
            
        }

        //Update already existing regions
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionsDTO updateRegionsDTO)
        {
            
                //map DTO to domain model
                var regionDomainModel = mapper.Map<Region>(updateRegionsDTO);

                regionDomainModel = await regionsRepositories.UpdateAsync(id, regionDomainModel);
                //find whether the given id exists
                if (regionDomainModel == null)
                {
                    return NotFound();
                }


                //Convert to DTO
                var regionDTO = mapper.Map<RegionDTO>(regionDomainModel);

                return Ok(regionDTO);
           
        }

        //Deleting regions
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id) { 
            var regionsDomainModel = await regionsRepositories.DeleteAsync(id);

            if (regionsDomainModel == null)
            {
                return NotFound();
            }


            //converting to DTO
            var regionDTO = mapper.Map<RegionDTO>(regionsDomainModel);
            return Ok(regionDTO);
        }
    }
}
