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
        public async Task<List<Walk>> GetAllWalksAsync()
        {
            return await _context.walks.Include(d => d.Difficulty).Include(r => r.Region).ToListAsync();
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
