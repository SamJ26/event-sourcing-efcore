namespace Project.EventSourcing;

public class Event
{
    public int Id { get; init; }
    public required Guid StreamId { get; init; }
    public required DateTime TimeStamp { get; init; }
    public required string DataType { get; init; }
    public required string Data { get; init; }
}