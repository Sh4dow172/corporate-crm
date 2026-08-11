using DirectoryService.Domain.VO;

namespace DirectoryService.Domain;

public class Position
{
    //ef core
    private Position() {}

    public Position(
        Guid id,
        Name name)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Identifier cannot be empty.", nameof(id));
        
        Id = id;
        Name = name;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public Guid Id { get; private set; }
    
    public Name Name { get; private set; } = null!;
    
    public DateTime CreatedAt { get; private set; }
    
    public DateTime UpdatedAt { get; private set; }
}