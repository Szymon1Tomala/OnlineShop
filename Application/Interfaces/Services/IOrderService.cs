using Application.Responses;
using Domain.Entities;

namespace Application.Interfaces.Services;

public interface IOrderService
{
    Task<OrderId> Add(UserId userId, IEnumerable<(ProductId ProductId, double Amount)> productAmounts, 
        DateTime orderDate, DateTime deliveryDate, CancellationToken cancellationToken);
    Task<OrderResponse?> Get(OrderId id, CancellationToken cancellationToken);
    Task<bool> Delete(OrderId id, CancellationToken cancellationToken);
}