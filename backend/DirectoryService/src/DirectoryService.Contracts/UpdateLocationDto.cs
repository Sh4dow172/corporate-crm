namespace DirectoryService.Contracts;

public sealed record UpdateLocationDto(string Name, string Country, string Region ,string City, string Street, string Apartment, string HouseNumber);