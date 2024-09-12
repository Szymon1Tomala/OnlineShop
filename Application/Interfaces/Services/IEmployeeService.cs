using Application.Responses;
using Domain.Entities;

namespace Application.Interfaces.Services;

public interface IEmployeeService
{
    Task<EmployeeId> Add(string firstName, string lastName, DepartmentId departmentId, CancellationToken cancellationToken);
    Task<EmployeeResponse?> Get(EmployeeId id, CancellationToken cancellationToken);
    Task Delete(EmployeeId id, CancellationToken cancellationToken);
}