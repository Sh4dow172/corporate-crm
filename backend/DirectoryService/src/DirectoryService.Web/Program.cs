using DirectoryService.Core.Locations;
using DirectoryService.Infrastructure.Postgres;
using DirectoryService.Infrastructure.Postgres.Database;
using DirectoryService.Infrastructure.Postgres.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("PostgresConnection")
                       ?? throw new InvalidOperationException("Строка подключения 'PostgresConnection' не найдена в appsettings.json.");

var repositoryProvider = builder.Configuration["RepositorySettings:Provider"];

if (string.Equals(repositoryProvider, "Dapper", StringComparison.OrdinalIgnoreCase))
{
    builder.Services.AddScoped<IDbConnectionFactory>(sp => new NpgsqlConnectionFactory(connectionString));
    builder.Services.AddScoped<ILocationRepository, DapperLocationRepository>();
}
else
{
    builder.Services.AddScoped<ILocationRepository, EfLocationRepository>();
}

builder.Services.AddDbContext<DirectoryServiceDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddScoped<CreateLocationValidator>();
builder.Services.AddScoped<LocationsService>();

WebApplication app = builder.Build();

// Minimal API endpoints
app.MapGet("/", () => "DirectoryService is running!");

app.MapGet("/health", () => Results.Ok(new
{
    status = "healthy",
    timestamp = DateTimeOffset.UtcNow
}));

// MVC контроллеры
app.MapControllers();

if (!app.Environment.IsProduction())
{
    app.MapOpenApi();              // /openapi/v1.json
    app.MapScalarApiReference();   // /scalar/v1
}

await app.RunAsync();
