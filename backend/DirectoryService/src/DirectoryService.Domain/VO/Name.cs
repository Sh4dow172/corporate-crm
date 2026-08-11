namespace DirectoryService.Domain.VO;

public sealed record Name
{
    private const int MinLength = 3;
    private const int MaxLength = 150;
    
    public Name(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(value));
        
        if (value.Length < MinLength || value.Length > MaxLength)
            throw new ArgumentException($"Value must be between {MinLength} and {MaxLength} characters.", nameof(value));
        
        Value = value.Trim();
    }
    
    public string Value { get; }
}