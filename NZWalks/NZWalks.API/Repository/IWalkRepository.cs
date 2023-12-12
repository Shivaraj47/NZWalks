using NZWalks.API.Model.Domain;

namespace NZWalks.API.Repository
{
    public interface IWalkRepository
    {
        Task<IEnumerable<Walk>> GetAllWalksAsync();
        Task<Walk> GetWalkByIdAsync(Guid id);

       Task<Walk>  CreateWalkAsync(Walk walk);

       Task<Walk> UpdateWalkAsync(Guid id, Walk walk);

       Task<Walk> DeleteWalkAsync(Guid id);

    }
}
