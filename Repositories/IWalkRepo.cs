using WalkApp.Models;

namespace WalkApp.Repositories
{
    public interface IWalkRepo
    {
        Task<Walk> CreateAsync(Walk walk);
        Task<List<Walk>> GetAllWalksAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true, int pageSize = 50,int pageNumber = 1); 
        Task<Walk> GetAWalkAsync(Guid id);
        Task<Walk> DeleteAWalkAsync(Guid id);
    }
}
