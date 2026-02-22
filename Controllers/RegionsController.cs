using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WalkApp.Data;
using WalkApp.Models;
using WalkApp.Models.DTO;
using WalkApp.Repositories;
using WalkApp.Mappings;

namespace WalkApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly TRWalksDbContext _dbContext;
        private readonly IRegionRepo _regionRepo;
        private readonly IMapper _mapper;


        public RegionsController(IRegionRepo regionRepo, IMapper mapper)
        {
            _regionRepo = regionRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            var regionsDomain = await _regionRepo.GetAllRegionsAsync();
            return Ok(new { message = "Regions retrieved successfully", data = _mapper.Map<List<RegionDTO>>(regionsDomain) });
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetARegion([FromRoute] Guid id)
        {
            var region = await _regionRepo.GetARegionAsync(id);
            if (region == null)
            {
                return NotFound(new { message = "Region not found" });
            }
            
            return Ok(new { message = "Region retrieved successfully", data = _mapper.Map<RegionDTO>(region)});
        }

        [HttpPost]
        public async Task<IActionResult> AddARegion([FromBody] AddRequestRegionDTO regionDto)
        {
            if (regionDto == null)
                return BadRequest(new { message = "Invalid region data" });

            var region = _mapper.Map<Region>(regionDto);
            region = await _regionRepo.AddARegionAsync(region);
            var resultDto = _mapper.Map<RegionDTO>(region);

            return StatusCode(201, new { message = "Region saved successfully", data = resultDto });
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateARegion([FromRoute] Guid id, [FromBody] Region region)
        {
            var existingRegion = await _regionRepo.GetARegionAsync(id);
            if (existingRegion == null)
            {
                return NotFound(new { message = "Region not found" });
            }

            region.Id = id;
            await _regionRepo.UpdateARegionAsync(region);
            return Ok(new { message = "Region updated successfully" });
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteARegion([FromRoute] Guid id)
        {
            var region = await _regionRepo.GetARegionAsync(id);
            if (region == null)
            {
                return NotFound(new { message = "Region not found" });
            }
            await _regionRepo.DeleteARegionAsync(id);
            return Ok(new { message = "Region deleted successfully" });
        }
    }
}
