using DirectoryService.Domain;
using Microsoft.EntityFrameworkCore;

namespace DirectoryService.Infrastructure.Postgres;

public sealed class DirectoryServiceDbContext : DbContext
{
    public DirectoryServiceDbContext(DbContextOptions<DirectoryServiceDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DirectoryServiceDbContext).Assembly);
    }
    
    public DbSet<Department> Departments { get; private set; } = null!;
    public DbSet<Location> Locations { get; private set; } = null!;
    public DbSet<Position> Positions { get; private set; } = null!;
    public DbSet<DepartmentLocation> DepartmentLocations { get; private set; } = null!;
    public DbSet<DepartmentPosition> DepartmentPositions { get; private set; } = null!;

}