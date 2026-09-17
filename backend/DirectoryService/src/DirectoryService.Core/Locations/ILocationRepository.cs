using DirectoryService.Domain;

namespace DirectoryService.Core.Locations;

public interface ILocationRepository
{
    public Task<bool> ExistsByNameAsync(string name);
    
    public Task AddAsync(Location location);
}