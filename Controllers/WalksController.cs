using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WalkApp.Models;
using WalkApp.Models.DTO;
using WalkApp.Repositories;

namespace WalkApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWalkRepo _walkRepo;
        public WalksController(IMapper mapper, IWalkRepo walkRepo)
        {
            _mapper = mapper;
            _walkRepo = walkRepo;
        }
        [HttpPost]
        public async Task<IActionResult> AddAWalk([FromBody] AddWalkRequestDTO addWalkRequestDTO)
        {
            var walkDomainModel = _mapper.Map<AddWalkRequestDTO, Walk>(addWalkRequestDTO);
            await _walkRepo.CreateAsync(walkDomainModel);
            return Ok(_mapper.Map<Walk, WalkDTO>(walkDomainModel));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllWalks()
        {
            var walkDomainModels = await _walkRepo.GetAllWalksAsync();
            return Ok(_mapper.Map<List<Walk>, List<WalkDTO>>(walkDomainModels));
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAWalk([FromRoute] Guid id)
        {
            var walkDomainModel = await _walkRepo.GetAWalkAsync(id);
            if (walkDomainModel == null)
                return NotFound(new { message = "Walk not found" });
            return Ok(_mapper.Map<Walk, WalkDTO>(walkDomainModel));

        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAWalk([FromRoute] Guid id)
        {
            var region = await _walkRepo.GetAWalkAsync(id);
            if (region == null)
            {
                return NotFound(new { message = "Region not found" });
            }
            await _walkRepo.DeleteAWalkAsync(id);
            return Ok(new { message = "Walk deleted successfully" });

        }
    }
}
