using Application.Interfaces.Services;
using Application.Responses;
using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Infrastructure.Services;

public class OrderService(DatabaseContext context) : IOrderService
{
    public async Task<OrderId> Add(UserId userId, IEnumerable<(ProductId ProductId, double Amount)> productAmounts, 
        DateTime orderDate, DateTime deliveryDate, CancellationToken cancellationToken)
    {
        var productAmountsToAdd = productAmounts
            .Select(x => new ProductAmount
            {
                Id = ProductAmountId.New(),
                ProductId = x.ProductId,
                Amount = x.Amount
            });

        var order = Order.Create(userId, orderDate, deliveryDate);

        await context.Orders.AddAsync(order, cancellationToken);
        await context.ProductAmounts.AddRangeAsync(productAmountsToAdd, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        
        return order.Id;
    }

    public async Task<OrderResponse?> Get(OrderId id, CancellationToken cancellationToken)
    {
        var order = await context.Orders.FindAsync(new object?[] { id }, cancellationToken);

        if (order is null)
        {
            return null;
        }

        return new OrderResponse(order.Id.Value, order.UserId.Value, order.OrderDate, order.DeliveryDate);
    }

    public async Task Delete(OrderId id, CancellationToken cancellationToken)
    {
        await context.Orders
            .Where(x => x.Id == id)
            .ExecuteDeleteAsync(cancellationToken);
    }
}