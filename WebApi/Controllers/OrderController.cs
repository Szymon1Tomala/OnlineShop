using Application.Interfaces.Services;
using WebApi.Requests;
using Application.Responses;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public static class OrderController
{
    private const string Prefix = "/orders";
    
    public static void MapOrderEndpoints(this WebApplication app)
    {
        app.MapGet($"{Prefix}/{{id:guid}}", async 
        (
            [FromRoute] Guid id,
            [FromServices] IOrderService service,
            CancellationToken cancellationToken
        ) =>
        {
            var order = await service.Get(new OrderId(id), cancellationToken);
            
            return order is not null ? Results.Ok(order) : Results.NotFound();
        });

        app.MapPost($"{Prefix}/", async 
        (
            [FromBody] AddOrderRequest request,
            [FromServices] IOrderService service, 
            CancellationToken cancellationToken
        ) =>
        {
            var productAmounts = request.ProductAmounts
                .Select(x => (new ProductId(x.ProductId), x.Amount));
            
            var id = await service.Add(new UserId(request.UserId), productAmounts, request.OrderDate, 
                request.DeliveryDate, cancellationToken);
            
            return Results.Ok(id);
        });

        app.MapDelete($"{Prefix}/{{id:guid}}", async
        (
            [FromRoute] Guid id,
            [FromServices] IOrderService service,
            CancellationToken cancellationToken
        ) =>
        {
            var wasDeleted = await service.Delete(new OrderId(id), cancellationToken);

            return wasDeleted ? Results.Ok() : Results.NotFound();
        });
    }

}