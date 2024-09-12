using Application.Interfaces.Services;
using Application.Responses;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Infrastructure.Services;

public class EmployeeService(DatabaseContext context) : IEmployeeService
{
    public async Task<EmployeeId> Add(string firstName, string lastName, DepartmentId departmentId, CancellationToken cancellationToken)
    {
        var employee = Employee.Create(firstName, lastName, departmentId);
        
        await context.Employees.AddAsync(employee, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return employee.Id;
    }

    public async Task<EmployeeResponse?> Get(EmployeeId id, CancellationToken cancellationToken)
    {
        var employee = await context.Employees.FindAsync([id], cancellationToken);

        if (employee is null)
            return null;
        
        return new EmployeeResponse(employee.Id.Value, employee.FirstName, employee.LastName, employee.Email);
    }

    public async Task Delete(EmployeeId id, CancellationToken cancellationToken)
    {
        await context.Employees
            .Where(x => x.Id == id)
            .ExecuteDeleteAsync(cancellationToken);
    }
}