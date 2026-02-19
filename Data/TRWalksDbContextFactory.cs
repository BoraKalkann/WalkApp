using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace WalkApp.Data
{
    public class TRWalksDbContextFactory : IDesignTimeDbContextFactory<TRWalksDbContext>
    {
        public TRWalksDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<TRWalksDbContext>();
            var conn = configuration.GetConnectionString("ConnectionString");
            optionsBuilder.UseSqlServer(conn);

            return new TRWalksDbContext(optionsBuilder.Options);
        }
    }
}