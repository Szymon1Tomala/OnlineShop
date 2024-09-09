using StronglyTypedIds;

namespace Domain.Entities;

[StronglyTypedId]
public readonly partial struct ProductId;

public class Product
{
    public required ProductId Id { get; init; }
}