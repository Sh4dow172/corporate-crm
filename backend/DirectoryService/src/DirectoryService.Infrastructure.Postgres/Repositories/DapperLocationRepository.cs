using System.Data;
using System.Data.Common;
using Dapper;
using DirectoryService.Core.Locations;
using DirectoryService.Domain;
using DirectoryService.Infrastructure.Postgres.Database;
using Microsoft.Extensions.Logging;

namespace DirectoryService.Infrastructure.Postgres.Repositories;

public sealed partial class DapperLocationRepository : ILocationRepository
{
    private readonly IDbConnectionFactory _connectionFactory;
    private readonly ILogger<DapperLocationRepository> _logger;

    public DapperLocationRepository(IDbConnectionFactory connectionFactory, ILogger<DapperLocationRepository> logger)
    {
        _connectionFactory = connectionFactory;
        _logger = logger;
    }

    public async Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        using var connection = _connectionFactory.CreateConnection();

        await ((DbConnection)connection).OpenAsync(cancellationToken);
        const string locationExistSql = """
                                         SELECT EXISTS(SELECT 1 FROM locations WHERE name = @Name);
                                         """;
        
        var command = new CommandDefinition(
            commandText: locationExistSql,
            parameters: new { Name = name },
            cancellationToken: cancellationToken);

        return await connection.ExecuteScalarAsync<bool>(command);
    }

    public async Task AddAsync(Location location, CancellationToken cancellationToken = default)
    {
        try
        {
            const string locationInsertSql = """
                                                 INSERT INTO locations (id, name, country, region, city, street, house_number, apartment, created_at, updated_at)
                                                 VALUES (@Id, @Name, @Country, @Region, @City, @Street, @HouseNumber, @Apartment, @CreatedAt, @UpdatedAt);
                                             """;
        
            var parameters = new
            {
                Id = location.Id,
                Name = location.Name.Value,
                Country = location.Address.Country,
                Region = location.Address.Region,
                City = location.Address.City,
                Street = location.Address.Street,
                HouseNumber = location.Address.HouseNumber,
                Apartment = location.Address.Apartment,
                CreatedAt = location.CreatedAt,
                UpdatedAt = location.UpdatedAt
            };
        
            using var connection = _connectionFactory.CreateConnection();
            await ((DbConnection)connection).OpenAsync(cancellationToken);
            
            var command = new CommandDefinition(
                commandText: locationInsertSql,
                parameters: parameters,
                cancellationToken: cancellationToken);

            await connection.ExecuteAsync(command);
        }
        catch (Exception ex)
        {
            LogDapperSaveError(_logger, ex, location.Id);
            throw;
        }
    }
    
    [LoggerMessage(
        EventId = 1002, // Уникальный ID для логов Dapper
        Level = LogLevel.Error,
        Message = "Не удалось сохранить локацию с ID {LocationId} через Dapper в базу данных PostgreSQL")]
    private static partial void LogDapperSaveError(ILogger logger, Exception ex, Guid locationId);
}