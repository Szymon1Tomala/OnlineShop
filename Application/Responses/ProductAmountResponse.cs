namespace Application.Responses;

public record ProductAmountResponse(Guid Id, ProductResponse Product, double Amount);