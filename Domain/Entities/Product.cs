using StronglyTypedIds;

namespace Domain.Entities;

[StronglyTypedId]
public readonly partial struct ProductId;

public class Product
{
    public required ProductId Id { get; init; }
    public required int Code { get; set; }
    public required string Name { get; set; }
    public required double Price { get; set; }
}