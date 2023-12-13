using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Model.Domain;

namespace NZWalks.API.Repository
{
    public class SQLDifiicultyRepository : IDifficultyRepository
    {
        private readonly NZWalkDbContext dbContext;

        public SQLDifiicultyRepository(NZWalkDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<WalkDifficulty> CreateAsync(WalkDifficulty difficulty)
        {
            difficulty.Id = Guid.NewGuid();
           await dbContext.walkDifficulties.AddAsync(difficulty);
           await dbContext.SaveChangesAsync();
            return difficulty;
        }

        public async Task<WalkDifficulty> DeleteAsync(Guid id)
        {
            var existDifficulty = await dbContext.walkDifficulties.FirstOrDefaultAsync(x => x.Id == id);
            if (existDifficulty == null)
            {
                return null;
            }

            dbContext.walkDifficulties.Remove(existDifficulty);
            await dbContext.SaveChangesAsync();
            return existDifficulty;
            
        }

        public async Task<List<WalkDifficulty>> GetAllAsync()
        {
            var difficulty = await dbContext.walkDifficulties.ToListAsync();

            return difficulty;
        }

        public async Task<WalkDifficulty> GetByIdAsync(Guid id)
        {
            var existDifficulty = await dbContext.walkDifficulties.FirstOrDefaultAsync(x => x.Id == id);
            if (existDifficulty == null)
            {
                return null;
            }
            return existDifficulty;
        }

        public async Task<WalkDifficulty> UpdateDiffSync(WalkDifficulty difficulty, Guid id)
        {
            var existDifficulty = await dbContext.walkDifficulties.FirstOrDefaultAsync(x => x.Id == id);

            if (existDifficulty == null)
            {
                return null;
            }

            existDifficulty.Name = difficulty.Name;

            return existDifficulty;

        }
    }
}
