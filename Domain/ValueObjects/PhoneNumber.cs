using Domain.Entities;
using StronglyTypedIds;

namespace Domain.ValueObjects;

[StronglyTypedId]
public readonly partial struct PhoneNumberId;

public class PhoneNumber
{
    public PhoneNumberId Id {get; init;}
    public int DirectNumber {get; set;}
    public string Number {get; set;}
    public User User { get; set; }
    public Employee Employee { get; set; }
}