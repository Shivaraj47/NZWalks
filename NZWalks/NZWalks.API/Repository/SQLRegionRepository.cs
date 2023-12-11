using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Model.Domain;

namespace NZWalks.API.Repository
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly NZWalkDbContext dbContext;

        public SQLRegionRepository(NZWalkDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Region> AddRegionAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            await dbContext.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteAsync(Guid id)
        {
            var region = await dbContext.regions.FirstOrDefaultAsync(x => x.Id == id);
            if (region == null)
            {
                return null;
            }

            var regions = dbContext.regions.Remove(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<IEnumerable<Region>> GetAllRegionAsync()
        {
          return await dbContext.regions.ToListAsync();
        }

        public async Task<Region> GetByIdAsync(Guid id)
        {
          var region = await dbContext.regions.FirstOrDefaultAsync(x => x.Id == id);

          if(region == null)
            {
                return null;
            }

          return region;
        }

        public async Task<Region> UpdateRegionAsync(Region region, Guid id)
        {
            var existingRegion = await dbContext.regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null)
            {
                return null;
            }

            existingRegion.Code = region.Code;
            existingRegion.Area = region.Area;
            existingRegion.Lat = region.Lat;
            existingRegion.Long = region.Long;
            existingRegion.Name = region.Name;
            existingRegion.Population = region.Population;

            await dbContext.SaveChangesAsync();
            return existingRegion;
        }
    }
}
