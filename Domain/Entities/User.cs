using Domain.ValueObjects;
using StronglyTypedIds;

namespace Domain.Entities;

[StronglyTypedId]
public readonly partial struct UserId;

public class User
{
    public required UserId Id { get; init; }
    public required string FirstName { get; init; }
    public required string SecondName { get; init; }
    public required string Email { get; init; }
    public required PhoneNumber PhoneNumber {get; init; }
}