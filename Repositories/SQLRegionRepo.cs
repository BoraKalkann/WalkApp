using WalkApp.Data;
using WalkApp.Models;
using Microsoft.EntityFrameworkCore;

namespace WalkApp.Repositories
{


    public class SQLRegionRepo : IRegionRepo
    {
        private readonly TRWalksDbContext _Dbcontext;

        public SQLRegionRepo(TRWalksDbContext dbContext)
        {
            this._Dbcontext = dbContext;
        }

        public async Task<Region> AddARegionAsync(Region region)
        {
            await _Dbcontext.regions.AddAsync(region);
            await _Dbcontext.SaveChangesAsync();
            return region;
        }

        public async Task<List<Region>> GetAllRegionsAsync()
        {
            return await _Dbcontext.regions.ToListAsync();
        }

        public async Task<Region> GetARegionAsync(Guid id)
        {
            return await _Dbcontext.regions.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<Region> UpdateARegionAsync(Region region)
        {
            _Dbcontext.regions.Update(region);
            await _Dbcontext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteARegionAsync(Guid id)
        {
            var region = await _Dbcontext.regions.FirstOrDefaultAsync(o => o.Id == id);
            if (region != null)
            {
                _Dbcontext.regions.Remove(region);
                await _Dbcontext.SaveChangesAsync();
            }
            return region;
        }
    }
}
