namespace DirectoryService.Core.Locations;

public sealed class LocationNameAlreadyExistsException : Exception
{
    public LocationNameAlreadyExistsException()
    {
    }

    public LocationNameAlreadyExistsException(string message) : base(message)
    {
    }
    
    public LocationNameAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
    {
    }
}