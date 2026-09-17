namespace DirectoryService.Contracts;

public sealed record UpdateDepartmentDto(string Name, string Slug, Guid? ParentId);