namespace WebApi.Responses;

internal record ProductAmountResponse(Guid Id, ProductResponse Product, double Amount);