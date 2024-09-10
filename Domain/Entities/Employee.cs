using Domain.ValueObjects;
using StronglyTypedIds;

namespace Domain.Entities;

[StronglyTypedId]
public readonly partial struct EmployeeId;

public class Employee
{
    private Employee(string firstName, string lastName, DepartmentId departmentId)
    {
        Id = EmployeeId.New();
        FirstName = firstName;
        LastName = lastName;
        DepartmentId = departmentId;
    }

    public EmployeeId Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DepartmentId DepartmentId { get; set; }
    public string Email { get; init; }
    public PhoneNumberId PhoneNumberId {get; init; }
    

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