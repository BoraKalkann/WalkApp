using WalkApp.Models;

namespace WalkApp.Repositories
{
    public interface IRegionRepo
    {
        Task<List<Region>> GetAllRegionsAsync();
        Task<Region> GetARegionAsync(Guid id);
        Task<Region> AddARegionAsync(Region region);
        Task<Region> UpdateARegionAsync(Region region);
        Task<Region?> DeleteARegionAsync(Guid id);
    }
}
