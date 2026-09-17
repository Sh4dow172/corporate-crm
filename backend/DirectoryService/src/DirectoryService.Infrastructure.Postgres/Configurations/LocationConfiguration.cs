using DirectoryService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Postgres.Configurations;

public sealed class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("locations");
        
        builder.HasKey(l => l.Id).HasName("pk_locations");

        builder.Property(l => l.Id)
            .HasColumnName("id")
            .IsRequired();

        builder.ComplexProperty(l => l.Name, nb =>
        {
            nb.Property(n => n.Value)
                .HasColumnName("name")
                .HasMaxLength(150)
                .IsRequired();
        });

        builder.ComplexProperty(l => l.Address, ab =>
        {
            ab.Property(a => a.City)
                .HasColumnName("city")
                .HasMaxLength(100)
                .IsRequired();
            
            ab.Property(a => a.Country)
                .HasColumnName("country")
                .HasMaxLength(100)
                .IsRequired();

            ab.Property(a => a.Region)
                .HasColumnName("region")
                .HasMaxLength(100)
                .IsRequired();
            
            ab.Property(a => a.Street)
                .HasColumnName("street")
                .HasMaxLength(100)
                .IsRequired();
            
            ab.Property(a => a.Apartment)
                .HasColumnName("apartment")
                .HasMaxLength(50)
                .IsRequired();

            ab.Property(a => a.HouseNumber)
                .HasColumnName("house_number")
                .HasMaxLength(50)
                .IsRequired();
        });
        
        builder.Property(l => l.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();
        
        builder.Property(l => l.UpdatedAt)
            .HasColumnName("updated_at")
            .IsRequired();
    }
}