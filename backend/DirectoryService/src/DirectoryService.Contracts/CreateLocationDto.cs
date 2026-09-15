namespace DirectoryService.Contracts;

public sealed record CreateLocationDto(string Name, string Country, string Region ,string City, string Street, string HouseNumber);