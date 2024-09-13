using StronglyTypedIds;

namespace Domain.Entities;

[StronglyTypedId]
public readonly partial struct ProductId;

public class Product
{
    public ProductId Id { get; init; }
    public int Code { get; set; }
    public string Name { get; set; }
}