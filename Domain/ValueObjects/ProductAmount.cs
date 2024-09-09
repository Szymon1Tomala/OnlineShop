using Domain.Entities;

namespace Domain.ValueObjects;

public class ProductAmount
{
    public ProductId Id { get; init; }
    public double Amount { get; set; }    
}