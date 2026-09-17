namespace DirectoryService.Contracts;

public sealed record CreateDepartmentDto(string Name, string Slug, Guid? ParentId);