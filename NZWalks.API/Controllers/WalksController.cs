using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalksRepositories walksRepositories;
        public WalksController(IMapper mapper, IWalksRepositories walksRepositories) {
            this.mapper = mapper;
            this.walksRepositories = walksRepositories;
        }
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            
                //map from dto to domain model walk
                var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);

                await walksRepositories.CreateAsync(walkDomainModel);

                var walkDTO = mapper.Map<WalksDTO>(walkDomainModel);

                return Ok(walkDTO);
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery, [FromQuery] string? sortBy, 
            [FromQuery] bool? isAscending, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {
            var walksDomainModel = await walksRepositories.GetAllAsync(filterOn, filterQuery, sortBy, isAscending ?? true, pageNumber, pageSize);

            //throw new Exception("this is a new exception");
            //map domain model to DTO
            var walksDTO = mapper.Map<List<WalksDTO>>(walksDomainModel);

            return Ok(walksDTO);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetWalksById([FromRoute] Guid id)
        {
            var walksDomainModel = await walksRepositories.GetByIdAsync(id);
            if (walksDomainModel == null)
            {
                return NotFound();
            }

            //map domain model to DTO
            var walksDTO = mapper.Map<WalksDTO>(walksDomainModel);

            return Ok(walksDTO);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalksRequestDTO updateWalksRequest)
        {
           
                //map DTO to domain model
                var walkDomainModel = mapper.Map<Walk>(updateWalksRequest);


                walkDomainModel = await walksRepositories.UpdateWalkAsync(id, walkDomainModel);

                if (walkDomainModel == null)
                {
                    return NotFound();
                }

                //map domain model to DTO
                var walkDTO = mapper.Map<WalksDTO>(walkDomainModel);
                return Ok(walkDTO);
            

        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var walkDomainModel = await walksRepositories.DeleteWalkAsync(id);
            
            if(walkDomainModel == null)
            {
                return NotFound();
            }

            //map domain model to DTO
            var walksDTO = mapper.Map<WalksDTO>(walkDomainModel);

            return Ok(walksDTO);
        }
    }

        
}
