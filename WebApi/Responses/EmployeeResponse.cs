namespace WebApi.Responses;

public record EmployeeResponse(Guid Id, string FirstName, string LastName, string Email);