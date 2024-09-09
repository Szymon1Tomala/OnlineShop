using StronglyTypedIds;

namespace Domain.Entities;

[StronglyTypedId]
public readonly partial struct ReportId;

public class Report
{
    public required ReportId Id { get; init; }
    public required string Content { get; init; }
}