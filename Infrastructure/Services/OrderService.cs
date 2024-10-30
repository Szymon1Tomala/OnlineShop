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
        var order = Order.Create(userId, orderDate, deliveryDate);
        
        var productAmountsToAdd = productAmounts
            .Select(x => new ProductAmount
            {
                Id = ProductAmountId.New(),
                OrderId = order.Id,
                ProductId = x.ProductId,
                Amount = x.Amount
            });

        await context.Orders.AddAsync(order, cancellationToken);
        await context.ProductAmounts.AddRangeAsync(productAmountsToAdd, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        
        return order.Id;
    }

    public async Task<OrderResponse?> Get(OrderId id, CancellationToken cancellationToken)
    {
        var order = await context.Orders.FindAsync([id], cancellationToken);

        if (order is null)
        {
            return null;
        }

        var productAmounts = await context.ProductAmounts
            .Include(productAmount => productAmount.Product)
            .Where(x => x.OrderId == order.Id)
            .ToListAsync(cancellationToken);

        var productAmountsResponse = productAmounts
            .Select(x => new ProductAmountResponse(x.Id.Value,
                new ProductResponse(x.ProductId.Value, x.Product.Code, x.Product.Name), x.Amount))
            .ToList();
        
        return new OrderResponse(order.Id.Value, order.UserId.Value, productAmountsResponse, order.OrderDate, order.DeliveryDate);
    }

    public async Task<bool> Delete(OrderId id, CancellationToken cancellationToken)
    {
        var result = await context.Orders
            .Where(x => x.Id == id)
            .ExecuteDeleteAsync(cancellationToken);

        return result > 0;
    }
}