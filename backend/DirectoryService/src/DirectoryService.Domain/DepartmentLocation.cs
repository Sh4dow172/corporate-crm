namespace DirectoryService.Domain;

public class DepartmentLocation
{
    //ef core
    private DepartmentLocation() {}

    public DepartmentLocation(
        Guid id,
        Guid departmentId,
        Guid locationId,
        bool isPrimary = false)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Identifier cannot be empty.", nameof(id));
        
        if (departmentId == Guid.Empty)
            throw new ArgumentException("Department identifier cannot be empty.", nameof(departmentId));
        
        if (locationId == Guid.Empty)
            throw new ArgumentException("Location identifier cannot be empty.", nameof(locationId));
        
        Id = id;
        DepartmentId = departmentId;
        LocationId = locationId;
        IsPrimary = isPrimary;
    }
    
    public Guid Id { get; private set; }
    
    public Guid DepartmentId { get; private set; }
    
    public Guid LocationId { get; private set; }
    
    public bool IsPrimary { get; private set; }
}