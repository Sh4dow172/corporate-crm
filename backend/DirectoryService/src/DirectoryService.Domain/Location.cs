using DirectoryService.Domain.VO;

namespace DirectoryService.Domain;

public class Location
{
    //ef core
    private Location() {}

    public Location(
        Guid id,
        Name name,
        Address address)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Identifier cannot be empty.", nameof(id));
        
        Id = id;
        Name = name;
        Address = address;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public Guid Id { get; private set; }
    
    public Name Name { get; private set; } = null!;
    
    public Address Address { get; private set; } = null!;
    
    public DateTime CreatedAt { get; private set; }
    
    public DateTime UpdatedAt { get; private set; }
}