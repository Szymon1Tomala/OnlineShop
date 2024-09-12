using WebApi.Requests;
using WebApi.Responses;

namespace WebApi.Controllers;

public static class EmployeeController
{
    private const string EmployeePrefix = "/employees";
    
    public static void MapEmployeeEndpoints(this WebApplication app)
    {
        app.MapGet($"{EmployeePrefix}/{{id:guid}}", (Guid id) =>
        {
            var employee = // to do _employeeService.Get(id);
                new EmployeeResponse(id, "Michael", "Thompson", "michael@gmail.com");
            
            return Results.Ok(employee);
        });

        app.MapPost($"{EmployeePrefix}/", (AddEmployeeRequest request) =>
        {
            var id = // _employeeService.Add(request);
                Guid.NewGuid();
            return Results.Ok(id);
        });

        app.MapDelete($"{EmployeePrefix}/{{id:guid}}", (Guid id) =>
        {
            // _employeeService.Delete(id);

            return Results.Ok(id);
        });
    }

}