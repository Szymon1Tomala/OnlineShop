using Domain.ValueObjects;
using StronglyTypedIds;

namespace Domain.Entities;

[StronglyTypedId]
public readonly partial struct UserId;

public class User
{
    public UserId Id { get; init; }
    public string FirstName { get; init; }
    public string SecondName { get; init; }
    public string Email { get; init; }
    public PhoneNumber PhoneNumber {get; init; }
}