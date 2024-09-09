using Domain.Entities;

namespace Domain.ValueObjects;

public class ProductAmount
{
    public required ProductId Id { get; init; }
    public required double Amount { get; set; }    
}