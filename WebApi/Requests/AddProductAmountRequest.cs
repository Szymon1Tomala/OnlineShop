namespace WebApi.Requests;

public record AddProductAmountRequest(Guid ProductId, double Amount);