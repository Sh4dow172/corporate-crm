using DirectoryService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Postgres.Configurations;

public sealed class DepartmentPositionConfiguration : IEntityTypeConfiguration<DepartmentPosition>
{
    public void Configure(EntityTypeBuilder<DepartmentPosition> builder)
    {
        builder.ToTable("department_positions");
        
        builder.HasKey(dp => dp.Id).HasName("pk_department_positions");
        
        builder.Property(dp => dp.Id)
            .HasColumnName("id")
            .IsRequired();
        
        builder.Property(dp => dp.DepartmentId)
            .HasColumnName("department_id")
            .IsRequired();
        
        builder.Property(dp => dp.PositionId)
            .HasColumnName("position_id")
            .IsRequired();
        
        builder.HasOne<Department>()
            .WithMany()
            .HasForeignKey(dp => dp.DepartmentId)
            .HasConstraintName("fk_department_positions_departments_department_id")
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne<Position>()
            .WithMany()
            .HasForeignKey(dp => dp.PositionId)
            .HasConstraintName("fk_department_positions_positions_position_id")
            .OnDelete(DeleteBehavior.Cascade);
    }
}