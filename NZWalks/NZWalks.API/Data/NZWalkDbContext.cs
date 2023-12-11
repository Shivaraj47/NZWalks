using Microsoft.EntityFrameworkCore;
using NZWalks.API.Model.Domain;

namespace NZWalks.API.Data
{
    public class NZWalkDbContext: DbContext 
    {
        public NZWalkDbContext(DbContextOptions<NZWalkDbContext> options): base(options)
        {
            
        }

        //create Dbset properties

        public DbSet<Region> regions { get; set; }
        public DbSet<Walk> walks { get; set; }

        public DbSet<WalkDifficulty> walkDifficulties { get; set; }
    }
}
