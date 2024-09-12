namespace WebApi.Requests;

public record AddOrderRequest(Guid UserId, ICollection<AddProductAmountRequest> ProductAmounts, DateTime OrderDate, DateTime DeliveryDate);