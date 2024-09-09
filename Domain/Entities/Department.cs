using StronglyTypedIds;

namespace Domain.Entities;

[StronglyTypedId]
public readonly partial struct DepartmentId;

public class Department
{
    public DepartmentId Id { get; init; }
    public int Code { get; init; }
    public string Name { get; set; }
}