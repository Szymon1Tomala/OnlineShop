using Application.Interfaces.Services;
using Application.Responses;
using WebApi.Requests;
using Domain.Entities;
using Domain.ValueObjects;

namespace WebApi.Controllers;

public static class EmployeeController
{
    private const string EmployeePrefix = "/employees";
    
    public static void MapEmployeeEndpoints(this WebApplication app)
    {
        app.MapGet($"{EmployeePrefix}/{{id:guid}}", async 
            (
                IEmployeeService service, 
                Guid id,
                CancellationToken cancellationToken
            ) =>
        {
            var employee = await service.Get(new EmployeeId(id), cancellationToken);
            
            return employee is not null ? Results.Ok(employee) : Results.NotFound();
        }).Produces<EmployeeResponse>();

        app.MapPost($"{EmployeePrefix}/", async 
            (
                IEmployeeService service, 
                AddEmployeeRequest request, 
                CancellationToken cancellationToken
            ) =>
        {
            var id = await service.Add(request.FirstName, request.LastName, new DepartmentId(request.DepartmentId), 
                request.Email, new PhoneNumberId(request.PhoneNumberId), cancellationToken);

            return Results.Ok(id);
        }).Produces<Guid>();

        app.MapDelete($"{EmployeePrefix}/{{id:guid}}", async 
            (
                Guid id, 
                IEmployeeService service, 
                CancellationToken cancellationToken
            ) =>
        {
            await service.Delete(new EmployeeId(id), cancellationToken);

            return Results.Ok();
        });
    }

}