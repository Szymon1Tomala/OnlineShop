using StronglyTypedIds;

namespace Domain.Entities;

[StronglyTypedId]
public readonly partial struct UserId;

public class User
{
    public UserId Id { get; init; }
}