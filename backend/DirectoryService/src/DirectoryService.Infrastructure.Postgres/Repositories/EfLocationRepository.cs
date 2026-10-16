using System.Data;
using DirectoryService.Core.Locations;
using DirectoryService.Domain;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace DirectoryService.Infrastructure.Postgres.Repositories;

public sealed partial class EfLocationRepository : ILocationRepository
{
    private readonly DirectoryServiceDbContext _dbContext;
    private readonly ILogger<EfLocationRepository> _logger;

    public EfLocationRepository(DirectoryServiceDbContext dbContext, ILogger<EfLocationRepository> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }
    
    public async Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Locations.AnyAsync(l => l.Name.Value == name, cancellationToken);
    }

    public async Task AddAsync(Location location, CancellationToken cancellationToken = default)
    {
        try
        {
            await _dbContext.Locations.AddAsync(location, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            LogSaveLocationError(_logger, ex, location.Id);
            throw;
        }
    }
    
    [LoggerMessage(
        EventId = 1001,
        Level = LogLevel.Error,
        Message = "Не удалось сохранить локацию с ID {LocationId} в базу данных PostgreSQL")]
    private static partial void LogSaveLocationError(ILogger logger, Exception ex, Guid locationId);
}