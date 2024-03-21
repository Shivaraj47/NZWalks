using NZWalks.API.Model.Domain;

namespace NZWalks.API.Repository
{
	public interface IDifficultyRepository
	{
		Task<List<WalkDifficulty>> GetAllAsync();

		Task<WalkDifficulty> CreateAsync(WalkDifficulty difficulty);

		Task<WalkDifficulty> GetByIdAsync(Guid id);

		Task<WalkDifficulty> UpdateDiffSync(WalkDifficulty difficulty, Guid id);

		Task<WalkDifficulty> DeleteAsync(Guid id);
	}
}
