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
    
    public async Task<Guid> Create(CreateLocationDto createLocationDto, CancellationToken cancellationToken)
    {
        await _createLocationValidator.ValidateAndThrowAsync(createLocationDto, cancellationToken);
        
        if (await _locationRepository.ExistsByNameAsync(createLocationDto.Name, cancellationToken))
        {
            throw new LocationNameAlreadyExistsException("Локация с таким названием уже существует");
        }
        
        var locationId = Guid.NewGuid();

        var address = new Address(
            createLocationDto.Country,
            createLocationDto.Region,
            createLocationDto.City,
            createLocationDto.Street,
            createLocationDto.Apartment,
            createLocationDto.HouseNumber);

        var name = new Name(createLocationDto.Name);
        
        await _locationRepository.AddAsync(new Location(locationId, name, address), cancellationToken);
        
        return locationId;
    }
}