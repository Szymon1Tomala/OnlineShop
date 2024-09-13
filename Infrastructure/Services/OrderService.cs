using Application.Interfaces.Services;
using Application.Responses;
using Domain.Entities;
using Domain.ValueObjects;
using Persistence.Context;

namespace Infrastructure.Services;

public class OrderService(DatabaseContext context) : IOrderService
{
    public async Task<OrderId> Add(UserId userId, ICollection<(ProductId ProductId, double Amount)> productAmounts, 
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

    public Task<OrderResponse?> Get(OrderId id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Delete(OrderId id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}