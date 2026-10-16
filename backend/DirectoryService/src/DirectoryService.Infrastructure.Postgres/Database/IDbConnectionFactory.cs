using System.Data;

namespace DirectoryService.Infrastructure.Postgres.Database;

public interface IDbConnectionFactory
{
    IDbConnection CreateConnection();
}