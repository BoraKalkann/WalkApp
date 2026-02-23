using Microsoft.EntityFrameworkCore;
using WalkApp.Data;
using WalkApp.Models;

namespace WalkApp.Repositories
{
    public class SQLWalkRepo : IWalkRepo
    {
        private readonly TRWalksDbContext _context;
        public SQLWalkRepo(TRWalksDbContext tRWalksDbContext)
        {
            _context = tRWalksDbContext;
        }
        public async Task<Walk> CreateAsync(Walk walk)
            {
               await _context.walks.AddAsync(walk);
               await _context.SaveChangesAsync();
               return walk;
        }
        public async Task<List<Walk>> GetAllWalksAsync(string? filterOn = null,
            string? filterQuery = null, string? sortBy = null, bool isAscending = true,int pageSize=50 , int pageNumber=1)
        {
            var walks = _context.walks.Include(d => d.Difficulty).Include(r => r.Region).AsQueryable();

            
            if (!string.IsNullOrEmpty(filterOn) && !string.IsNullOrEmpty(filterQuery))
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(o => o.Name.Contains(filterQuery));
                }
            }

            
            if (!string.IsNullOrEmpty(sortBy))
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(o => o.Name) : walks.OrderByDescending(o => o.Name);
                }
                else if (sortBy.Equals("Length", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(o => o.Length) : walks.OrderByDescending(o => o.Length);
                }
                
                else if (sortBy.Equals("Difficulty", StringComparison.OrdinalIgnoreCase))
                {
                    
                    if (isAscending)
                    {
                        walks = walks.OrderBy(o =>
                            o.Difficulty.Name == "Kolay" ? 1 :
                            o.Difficulty.Name == "Orta" ? 2 :
                            o.Difficulty.Name == "Zor" ? 3 : 4);
                    }
                    else
                    {
                        walks = walks.OrderByDescending(o =>
                            o.Difficulty.Name == "Kolay" ? 1 :
                            o.Difficulty.Name == "Orta" ? 2 :
                            o.Difficulty.Name == "Zor" ? 3 : 4);
                    }
                }
            }
            var skipPages = (pageNumber - 1) * pageSize;

            return await walks.Skip(skipPages).Take(pageSize).ToListAsync();
        }

        
        public async Task<Walk> GetAWalkAsync(Guid id)
        {
            return await _context.walks.Include(d => d.Difficulty).Include(r => r.Region).FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<Walk> DeleteAWalkAsync(Guid id)
        {
            var walk = await _context.walks.FirstOrDefaultAsync(o => o.Id == id);
            if (walk == null)
            {
                return null;
            }
            _context.walks.Remove(walk);
            await _context.SaveChangesAsync();
            return walk;



        }
        }
}
