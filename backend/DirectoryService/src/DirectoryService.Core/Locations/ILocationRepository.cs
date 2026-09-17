using DirectoryService.Domain;

namespace DirectoryService.Core.Locations;

public interface ILocationRepository
{
    public Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken = default);
    
    public Task AddAsync(Location location, CancellationToken cancellationToken = default);
}