namespace DirectoryService.Domain;

public class DepartmentPosition
{
    private DepartmentPosition() {}

    public DepartmentPosition(
        Guid id,
        Guid departmentId,
        Guid positionId)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Identifier cannot be empty.", nameof(id));
        
        if (departmentId == Guid.Empty)
            throw new ArgumentException("Department identifier cannot be empty.", nameof(departmentId));
        
        if (positionId == Guid.Empty)
            throw new ArgumentException("Position identifier cannot be empty.", nameof(positionId));
        
        Id = id;
        DepartmentId = departmentId;
        PositionId = positionId;
    }
    
    public Guid Id { get; private set; }
    
    public Guid DepartmentId { get; private set; }
    
    public Guid PositionId { get; private set; }
}