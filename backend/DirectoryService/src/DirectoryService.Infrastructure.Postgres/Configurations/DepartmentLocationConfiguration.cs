using DirectoryService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Postgres.Configurations;

public sealed class DepartmentLocationConfiguration : IEntityTypeConfiguration<DepartmentLocation>
{
    public void Configure(EntityTypeBuilder<DepartmentLocation> builder)
    {
        builder.ToTable("department_locations");
        
        builder.HasKey(dl => dl.Id).HasName("pk_department_locations");
        
        builder.Property(dl => dl.Id)
            .HasColumnName("id")
            .IsRequired();
        
        builder.Property(dl => dl.LocationId)
            .HasColumnName("location_id")
            .IsRequired();
        
        builder.Property(dl => dl.DepartmentId)
            .HasColumnName("department_id")
            .IsRequired();
        
        builder.Property(dl => dl.IsPrimary)
            .HasColumnName("is_primary")
            .IsRequired();
        
        builder.HasOne<Department>().
            WithMany()
            .HasForeignKey(dl => dl.DepartmentId)
            .HasConstraintName("fk_department_locations_departments_department_id")
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne<Location>()
            .WithMany()
            .HasForeignKey(dl => dl.LocationId)
            .HasConstraintName("fk_department_locations_locations_location_id")
            .OnDelete(DeleteBehavior.Cascade);
    }
}