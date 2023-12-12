using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using NZWalks.API.Data;
using NZWalks.API.Model.Domain;

namespace NZWalks.API.Repository
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly NZWalkDbContext dbContext;

        public SQLWalkRepository(NZWalkDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Walk> CreateWalkAsync(Walk walk)
        {
            //create id
            walk.Id = Guid.NewGuid();
           await dbContext.walks.AddAsync(walk);
           await dbContext.SaveChangesAsync();
            return walk;

        }

        public async Task<Walk> DeleteWalkAsync(Guid id)
        {
            var existWalk = await dbContext.walks.FirstOrDefaultAsync(x => x.Id == id);
            if (existWalk == null)
            {
                return null;
            }
            var walks = dbContext.walks.Remove(existWalk);
            await dbContext.SaveChangesAsync();
            return existWalk;

        }

        public async Task<IEnumerable<Walk>> GetAllWalksAsync()
        {
           return await dbContext.walks.ToListAsync();
           
        }

        public async Task<Walk> GetWalkByIdAsync(Guid id)
        {
            var walkdomain = await dbContext.walks.FirstOrDefaultAsync(x => x.Id == id);
            if (walkdomain == null)
            {
                return null;
            }
            return walkdomain;
        }

        public async Task<Walk> UpdateWalkAsync(Guid id, Walk walk)
        {
            var existingWalk = await dbContext.walks.FirstOrDefaultAsync(x => x.Id == id);

            if (existingWalk == null)
            {
                return null;
            }

            existingWalk.Name = walk.Name;
            existingWalk.Length = walk.Length;
            existingWalk.WalkDifficultyId = walk.WalkDifficultyId;
            existingWalk.RegionId = walk.RegionId;

            return existingWalk;
        }
    }
}
