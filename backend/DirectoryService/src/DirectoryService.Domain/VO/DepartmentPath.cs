namespace DirectoryService.Domain.VO;

public sealed record DepartmentPath
{
    public DepartmentPath(DepartmentPath? parentPath, Slug currentSlug)
    {
        if (currentSlug == null)
            throw new ArgumentException("Slug cannot be null", nameof(currentSlug));
        
        var assembledPath = parentPath is null 
            ? currentSlug.Value 
            : $"{parentPath.Value}/{currentSlug.Value}";

        if (assembledPath.StartsWith('/') || assembledPath.EndsWith('/'))
        {
            throw new ArgumentException("Path cannot start or end with a forward slash.", nameof(currentSlug));
        }

        if (assembledPath.Contains("//", StringComparison.Ordinal))
        {
            throw new ArgumentException("Path cannot contain a '//' slug.", nameof(parentPath));
        }
        
        Value = assembledPath;
    }
    
    public string Value { get; }
}