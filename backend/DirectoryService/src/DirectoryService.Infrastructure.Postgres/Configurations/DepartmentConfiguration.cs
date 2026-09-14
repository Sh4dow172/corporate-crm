using DirectoryService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Postgres.Configurations;

public sealed class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("departments");
        
        builder.HasKey(d => d.Id).HasName("pk_departments");

        builder.Property(d => d.Id)
            .HasColumnName("id")
            .IsRequired();

        builder.ComplexProperty(d => d.Name, nb =>
        {
            nb.Property(n => n.Value)
                .HasColumnName("name")
                .HasMaxLength(150)
                .IsRequired();
        });

        builder.ComplexProperty(d => d.Slug, sb =>
        {
            sb.Property(s => s.Value)
                .HasColumnName("slug")
                .HasMaxLength(100)
                .IsRequired();
        });

        builder.ComplexProperty(d => d.Path, pb =>
        {
            pb.Property(p => p.Value)
                .HasColumnName("path")
                .HasMaxLength(500)
                .IsRequired();
        });
        
        builder.Property(d => d.ParentId)
            .HasColumnName("parent_id");
        
        builder.HasOne<Department>()
            .WithMany()
            .HasForeignKey(d => d.ParentId)
            .HasConstraintName("fk_departments_departments_parent_id")
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Property(d => d.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();
        
        builder.Property(d => d.UpdatedAt)
            .HasColumnName("updated_at")
            .IsRequired();
    }
}