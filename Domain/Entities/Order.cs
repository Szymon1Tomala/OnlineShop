using Domain.ValueObjects;
using StronglyTypedIds;

namespace Domain.Entities;

[StronglyTypedId]
public readonly partial struct OrderId;

public class Order
{
    public OrderId Id { get; init; }
    public UserId UserId { get; init; }
    public IReadOnlyCollection<ProductAmount> ProductsAmounts { get; set; } = new List<ProductAmount>();
    public DateTime OrderDate { get; init; }
    public DateTime DeliveryDate { get; init; }
}