using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IRegionsRepositories
    {
        Task<List<Region>> GetAllAsync();

        Task<Region?> GetByIdAsync(Guid Id);
        
        Task<Region> CreateAsync(Region region);

        Task<Region?> UpdateAsync(Guid id, Region region);

        Task<Region?> DeleteAsync(Guid id);
    } 
}
