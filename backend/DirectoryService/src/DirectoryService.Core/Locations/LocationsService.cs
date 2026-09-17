using DirectoryService.Contracts;
using DirectoryService.Domain;
using DirectoryService.Domain.VO;
using FluentValidation;

namespace DirectoryService.Core.Locations;

public sealed class LocationsService
{
    private readonly ILocationRepository _locationRepository;
    private readonly CreateLocationValidator _createLocationValidator;

    public LocationsService(ILocationRepository locationRepository, CreateLocationValidator createLocationValidator)
    {
        _locationRepository = locationRepository;
        _createLocationValidator = createLocationValidator;
    }
    
    public async Task<Guid> Create(CreateLocationDto createLocationDto)
    {
        await _createLocationValidator.ValidateAndThrowAsync(createLocationDto);
        
        if (await _locationRepository.ExistsByNameAsync(createLocationDto.Name))
        {
            throw new LocationNameAlreadyExistsException("Location name already exists");
        }
        
        var locationId = Guid.NewGuid();

        var address = new Address(
            createLocationDto.Country,
            createLocationDto.Region,
            createLocationDto.City,
            createLocationDto.Street,
            createLocationDto.HouseNumber);

        var name = new Name(createLocationDto.Name);
        
        await _locationRepository.AddAsync(new Location(locationId, name, address));
        
        return locationId;
    }
}