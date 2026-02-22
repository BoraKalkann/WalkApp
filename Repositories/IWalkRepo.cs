using WalkApp.Models;

namespace WalkApp.Repositories
{
    public interface IWalkRepo
    {
        Task<Walk> CreateAsync(Walk walk);
        Task<List<Walk>> GetAllWalksAsync();
        Task<Walk> GetAWalkAsync(Guid id);
        Task<Walk> DeleteAWalkAsync(Guid id);
    }
}
