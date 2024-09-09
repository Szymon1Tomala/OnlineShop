using Domain.ValueObjects;
using StronglyTypedIds;

namespace Domain.Entities;

[StronglyTypedId]
public readonly partial struct EmployeeId;

public class Employee
{
    private Employee(string firstName, string secondName, DepartmentId departmentId)
    {
        Id = EmployeeId.New();
        FirstName = firstName;
        SecondName = secondName;
        DepartmentId = departmentId;
    }

    public required EmployeeId Id { get; set; }
    public required string FirstName { get; set; }
    public required string SecondName { get; set; }
    public DepartmentId DepartmentId { get; set; }
    public required string Email { get; init; }
    public required PhoneNumber PhoneNumber {get; init; }
    

    private static Employee Create(string firstName, string secondName, DepartmentId departmentId)
    {
        if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(secondName))
        {
            throw new ArgumentException("First Name and Second Name can' be null or empty");
        }

        if (departmentId.Value == Guid.Empty)
        {
            throw new ArgumentException("DepartmentId can' be empty");
        }

        return new Employee(firstName, secondName, departmentId);
    }
}