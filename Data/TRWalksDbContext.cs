using Microsoft.EntityFrameworkCore;
using WalkApp.Models;

namespace WalkApp.Data
{
    public class TRWalksDbContext : DbContext
    {
        public TRWalksDbContext(DbContextOptions<TRWalksDbContext> options) : base(options)
        {
        }
        public DbSet<Walk> walks { get; set; }
        public DbSet<Region> regions { get; set; }
        public DbSet<Difficulty> difficulties { get; set; }
    }
}

