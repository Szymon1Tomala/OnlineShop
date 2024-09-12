using WebApi.Requests;
using WebApi.Responses;

namespace WebApi.Controllers;

public static class OrderController
{
    private const string Prefix = "/orders";
    
    public static void MapOrderEndpoints(this WebApplication app)
    {
        app.MapGet($"{Prefix}/{{id:guid}}", (Guid id) =>
        {
            var order = // to do _orderService.Get(id);
                new OrderResponse(id, new UserResponse(), new List<ProductAmountResponse>(), DateTime.Today, DateTime.Today.AddDays(7));
            
            return Results.Ok(order);
        });

        app.MapPost($"{Prefix}/", (AddOrderRequest request) =>
        {
            var id = // _orderService.Add(request);
                Guid.NewGuid();
            return Results.Ok(id);
        });

        app.MapDelete($"{Prefix}/{{id:guid}}", (Guid id) =>
        {
            // _orderService.Delete(id);

            return Results.Ok(id);
        });
    }

}