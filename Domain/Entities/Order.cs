using System.Dynamic;
using Domain.ValueObjects;
using StronglyTypedIds;

namespace Domain.Entities;

[StronglyTypedId]
public readonly partial struct OrderId;

public class Order
{
    private Order(UserId userId, DateTime orderDate, DateTime deliveryDate)
    {
        Id = OrderId.New();
        UserId = userId;
        OrderDate = orderDate;
        DeliveryDate = deliveryDate;
    }

    public static Order Create(UserId userId, DateTime orderDate, DateTime deliveryDate)
    {
        if (userId.Value == Guid.Empty)
        {
            throw new ArgumentException("UserId can't be empty");
        }

        if (deliveryDate < orderDate)
        {
            throw new ArgumentException("Delivery date can't be earlier than order date");
        }
        
        return new Order(userId, orderDate, deliveryDate);
    }

    public OrderId Id { get; init; }
    public UserId UserId { get; init; }
    public User User { get; init; }
    public ICollection<ProductAmount> ProductAmounts { get; init; } = new List<ProductAmount>();
    public DateTime OrderDate { get; init; }
    public DateTime DeliveryDate { get; init; }
}