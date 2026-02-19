 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WalkApp.Data;
using WalkApp.Models;
using WalkApp.Models.DTO;
using WalkApp.Repositories;

namespace WalkApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepo _regionRepo;

        public RegionsController(IRegionRepo regionRepo)
        {
            _regionRepo = regionRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            var regionsDomain = await _regionRepo.GetAllRegionsAsync();
            var regionsDto = new List<RegionDTO>();
            foreach (var region in regionsDomain)
            {
                var regionDto = new RegionDTO
                {
                    Id = region.Id,
                    Name = region.Name,
                    Code = region.Code,
                    RegionImageUrl = region.RegionImageUrl
                };
                regionsDto.Add(regionDto);
            }
            return Ok(new { message = "Bölgeler başarıyla alındı", data = regionsDto });
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetARegion([FromRoute] Guid id)
        {
            var region = await _regionRepo.GetARegionAsync(id);
            if (region == null)
            {
                return NotFound(new { message = "Bölge bulunamadı" });
            }
            var regionsDto = new RegionDTO
            {
                Id = region.Id,
                Name = region.Name,
                Code = region.Code,
                RegionImageUrl = region.RegionImageUrl
            };
            return Ok(new { message = "Bölge başarıyla alındı", data = regionsDto });
        }

        [HttpPost]
        public async Task<IActionResult> AddARegion([FromBody] AddRequestRegionDTO regionDto)
        {
            if (regionDto == null)
                return BadRequest(new { message = "Geçersiz bölge verisi" });

            var region = new Region
            {
                Id = Guid.NewGuid(),
                Name = regionDto.Name.Trim(),
                Code = regionDto.Code.Trim(),
                RegionImageUrl = regionDto.RegionImageUrl
            };

            await _regionRepo.AddARegionAsync(region);

            var resultDto = new RegionDTO
            {
                Id = region.Id,
                Name = region.Name,
                Code = region.Code,
                RegionImageUrl = region.RegionImageUrl
            };

            return StatusCode(201, new { message = "Bölge başarıyla kaydedildi", data = resultDto });
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateARegion([FromRoute] Guid id, [FromBody] Region region)
        {
            var existingRegion = await _regionRepo.GetARegionAsync(id);
            if (existingRegion == null)
            {
                return NotFound(new { message = "Bölge bulunamadı" });
            }

            region.Id = id;
            await _regionRepo.UpdateARegionAsync(region);
            return Ok(new { message = "Bölge başarıyla güncellendi" });
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteARegion([FromRoute] Guid id)
        {
            var region = await _regionRepo.GetARegionAsync(id);
            if (region == null)
            {
                return NotFound(new { message = "Bölge bulunamadı" });
            }
            await _regionRepo.DeleteARegionAsync(id);
            return Ok(new { message = "Bölge başarıyla silindi" });
        }
    }
}
