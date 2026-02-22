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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Seed data for Difficulties
            var difficulties = new List<Difficulty>
                {
                    new Difficulty()
                    {
                        Id = Guid.Parse("54945523-37de-46c2-94b7-6a016bc7a6b5"),
                        Name = "Easy"
                    },
                    new Difficulty()
                    {
                        Id = Guid.Parse("e0c4b1de-1c76-4885-9397-33d5711f8dd8"),
                        Name = "Medium"
                    },
                    new Difficulty()
                    {
                        Id = Guid.Parse("da73f78b-eea2-434d-a0db-b38543e7c371"),
                        Name = "Hard"
                    }
                };
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            var regions = new List<Region>
                {
                    new Region()
                    {
                        Id = Guid.Parse("d1c4b1de-1c76-4885-9397-33d5711f8dd8"),
                        Name = "Ic Anadolu",
                        Code = "IC_ANADOLU",
                        RegionImageUrl = null
                    },
                    new Region()
                    {
                        Id = Guid.Parse("a0c4b1de-1c76-4885-9397-33d5711f8dd8"),
                        Name = "Karadeniz",
                        Code = "KARADENIZ",
                        RegionImageUrl = null
                    },
                    new Region()
                    {
                        Id = Guid.Parse("b0c4b1de-1c76-4885-9397-33d5711f8dd8"),
                        Name = "Akdeniz",
                        Code = "AKDENIZ",
                        RegionImageUrl = null
                    },
                    new Region()
                    {
                        Id = Guid.Parse("c0c4b1de-1c76-4885-9397-33d5711f8dd8"),
                        Name = "Marmara",
                        Code = "MARMARA",
                        RegionImageUrl = null
                    },
                    new Region()
                    {
                        Id = Guid.Parse("e0c4b1de-1c76-4885-9397-33d5711f8dd8"),
                        Name = "Ege",
                        Code = "EGE",
                        RegionImageUrl = null
                    },
                     new Region()
                    {
                        Id = Guid.Parse("f0c4b1de-1c76-4885-9397-33d5711f8dd8"),
                        Name = "Dogu Anadolu",
                        Code = "DOGU_ANADOLU",
                        RegionImageUrl = null
                     }
                };
            modelBuilder.Entity<Region>().HasData(regions);
        }
    }

   
}

