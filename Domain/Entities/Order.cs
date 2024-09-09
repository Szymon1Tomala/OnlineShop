using StronglyTypedIds;

namespace Domain.Entities;

[StronglyTypedId]
public readonly partial struct OrderId;

public class Order
{
    public required OrderId Id { get; init; }
    public required UserId UserId { get; init; }
    public required DateTime OrderDate { get; init; }
    public required DateTime DeliveryDate { get; init; }
}