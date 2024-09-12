namespace Application.Responses;

public record OrderResponse(Guid Id, UserResponse User, IReadOnlyCollection<ProductAmountResponse> ProductAmounts, DateTime OrderDate, DateTime DeliveryDate);