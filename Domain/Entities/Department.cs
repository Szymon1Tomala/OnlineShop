using StronglyTypedIds;

namespace Domain.Entities;

[StronglyTypedId]
public readonly partial struct DepartmentId;

public class Department
{
    public required DepartmentId Id { get; init; }
    public required int Code { get; init; }
    public required string Name { get; set; }
}