using Domain.Entities;
using StronglyTypedIds;

namespace Domain.ValueObjects;

[StronglyTypedId]
public readonly partial struct ProductAmountId;

public class ProductAmount
{
    public ProductAmountId Id { get; init; }
    public OrderId OrderId { get; init; }
    public Order Order { get; init; }
    public ProductId ProductId { get; init; }
    public Product Product { get; init; }
    public double Amount { get; set; }    
}