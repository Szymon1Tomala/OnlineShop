namespace WebApi.Requests;

public record AddEmployeeRequest(string FirstName, string LastName, Guid DepartmentId, string Email, Guid PhoneNumberId);