using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace DirectoryService.Domain.VO;

public sealed partial record Slug
{
    [GeneratedRegex(@"^[a-z0-9]+(?:-[a-z0-9]+)*$", RegexOptions.Compiled, matchTimeoutMilliseconds: 1000)]
    private static partial Regex GetSlugRegex();
    
    [SuppressMessage("Globalization", "CA1308:Normalize strings to uppercase", 
        Justification = "Слаги для URL традиционно должны быть строго в нижнем регистре.")]
    public Slug(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(value));
        
        var cleaned = value.Trim().ToLowerInvariant();
        
        if (!GetSlugRegex().IsMatch(cleaned))
            throw new ArgumentException("Value is not a slug.", nameof(value));
        
        Value = cleaned;
    }
    
    public string Value { get; }
}