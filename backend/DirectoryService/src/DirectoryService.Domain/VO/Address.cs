namespace DirectoryService.Domain.VO;

public sealed record Address
{
    public Address(
        string country,
        string region,
        string city,
        string street,
        string houseNumber)
    {
        if (string.IsNullOrWhiteSpace(country))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(country));
        
        if (string.IsNullOrWhiteSpace(region))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(region));
        
        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(city));
        
        if (string.IsNullOrWhiteSpace(street))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(street));
        
        if (string.IsNullOrWhiteSpace(houseNumber))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(houseNumber));
        
        Country = country.Trim();
        Region = region.Trim();
        City = city.Trim();
        Street = street.Trim();
        HouseNumber = houseNumber.Trim();
    }
    public string Country { get; }
    public string Region { get; }
    public string City { get; }
    public string Street { get; }
    public string HouseNumber { get; }
}