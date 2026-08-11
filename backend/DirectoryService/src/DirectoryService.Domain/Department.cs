using DirectoryService.Domain.VO;

namespace DirectoryService.Domain;

public class Department
{
    //ef core
    private Department() {}

    public Department(
        Guid id,
        Name name,
        Slug slug,
        DepartmentPath? parentPath,
        Guid? parentId
    )
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Identifier cannot be empty.", nameof(id));
        }

        if (parentId == Guid.Empty)
        {
            throw new ArgumentException("Identifier cannot be empty.", nameof(parentId));
        }

        if (parentId.HasValue && parentPath == null)
        {
            throw new ArgumentException(
                "Parent path must be provided when a parent ID is specified to prevent tree corruption.",
                nameof(parentPath));
        }

        if (!parentId.HasValue && parentPath != null)
        {
            throw new ArgumentException(
                "Root department cannot have a parent path.",
                nameof(parentPath));
        }
        
        Id = id;
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Slug = slug ?? throw new ArgumentNullException(nameof(slug));
        Path = new DepartmentPath(parentPath, slug);
        ParentId = parentId;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public Guid Id { get; private set; }
    
    public Name Name { get; private set; } = null!;

    public Slug Slug { get; private set; } = null!;
    
    public DepartmentPath Path { get; private set; } = null!;

    public Guid? ParentId { get; private set; }
    
    public DateTime CreatedAt { get; private set; }
    
    public DateTime UpdatedAt { get; private set; }
}