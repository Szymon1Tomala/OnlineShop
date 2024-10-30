namespace Application.Responses;

public record OrderResponse(Guid Id, Guid UserId, DateTime OrderDate, DateTime DeliveryDate);