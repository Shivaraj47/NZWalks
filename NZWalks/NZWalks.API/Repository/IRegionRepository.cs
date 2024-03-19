using NZWalks.API.Model.Domain;

namespace NZWalks.API.Repository
{
	public interface IRegionRepository
	{
		Task<IEnumerable<Region>> GetAllRegionAsync();

		Task<Region> GetByIdAsync(Guid id);

		Task<Region> AddRegionAsync(Region region);

		Task<Region> DeleteAsync(Guid id);

		Task<Region> UpdateRegionAsync(Region region, Guid id);
	}
}
