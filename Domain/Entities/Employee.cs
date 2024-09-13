using Domain.ValueObjects;
using StronglyTypedIds;

namespace Domain.Entities;

[StronglyTypedId(Template.Guid)]
public readonly partial struct EmployeeId;

public class Employee
{
    private Employee(string firstName, string lastName, DepartmentId departmentId, string email, PhoneNumberId phoneNumberId)
    {
        Id = EmployeeId.New();
        FirstName = firstName;
        LastName = lastName;
        DepartmentId = departmentId;
        Email = email;
        PhoneNumberId = phoneNumberId;
    }

    public EmployeeId Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DepartmentId DepartmentId { get; set; }
    public Department Department { get; set; }
    public string Email { get; init; }
    public PhoneNumberId PhoneNumberId {get; init; }
    public PhoneNumber PhoneNumber { get; set; }
    

    public static Employee Create(string firstName, string secondName, DepartmentId departmentId, string email, PhoneNumberId phoneNumberId)
    {
        if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(secondName))
        {
            throw new ArgumentException("First Name and Last Name can't be null or empty");
        }

        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("Email can't be null or empty");
        }

        if (departmentId.Value == Guid.Empty)
        {
            throw new ArgumentException("DepartmentId can't be empty");
        }
        
        if (phoneNumberId.Value == Guid.Empty)
        {
            throw new ArgumentException("PhoneNumberId can't be empty");
        }

        return new Employee(firstName, secondName, departmentId, email, phoneNumberId);
    }
}