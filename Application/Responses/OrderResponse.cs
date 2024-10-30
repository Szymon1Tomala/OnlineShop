namespace Application.Responses;

public record OrderResponse(Guid Id, Guid UserId, IReadOnlyCollection<ProductAmountResponse> ProductAmounts, DateTime OrderDate, DateTime DeliveryDate);