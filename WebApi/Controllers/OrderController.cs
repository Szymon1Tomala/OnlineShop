using Application.Interfaces.Services;
using WebApi.Requests;
using Application.Responses;
using Domain.Entities;

namespace WebApi.Controllers;

public static class OrderController
{
    private const string Prefix = "/orders";
    
    public static void MapOrderEndpoints(this WebApplication app)
    {
        app.MapGet($"{Prefix}/{{id:guid}}", (Guid id) =>
        {
            var order = await orderService.Get(id);
                
            
            return Results.Ok(order);
        });

        app.MapPost($"{Prefix}/", async 
        (
            AddOrderRequest request,
            IOrderService service, 
            CancellationToken cancellationToken
        ) =>
        {
            var productAmounts = request.ProductAmounts
                .Select(x => (new ProductId(x.ProductId), x.Amount));
            
            var id = service.Add(new UserId(request.UserId), productAmounts, request.OrderDate, 
                request.DeliveryDate, cancellationToken);
            
            return Results.Ok(id);
        });

        app.MapDelete($"{Prefix}/{{id:guid}}", (Guid id) =>
        {
            // _orderService.Delete(id);

            return Results.Ok(id);
        });
    }

}