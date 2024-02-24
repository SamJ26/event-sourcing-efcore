using System;

namespace EventSourcing.Library;

public sealed class EventMetadata
{
    public required Guid StreamId { get; init; }
    public required DateTime TimeStamp { get; init; }
}