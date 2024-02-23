using Project.Events;

namespace Project;

public sealed class GameAggregate : AggregateBase
{
    public DateTime? DateTimeStart { get; private set; }
    public DateTime? DateTimeEnd { get; private set; }

    public bool IsTerminated => DateTimeEnd is null;

    public GameAggregate()
    {
    }

    public override void Apply(EventBase @event, EventMetadata eventMeta)
    {
        switch (@event)
        {
            case GameStartedEvent e:
                OnEvent(e, eventMeta);
                return;
            case GameSavedEvent e:
                OnEvent(e, eventMeta);
                return;
            case GameTerminatedEvent e:
                OnEvent(e, eventMeta);
                return;
            default:
                throw new Exception("Unknown event!");
        }
    }

    private void OnEvent(GameStartedEvent e, EventMetadata meta)
    {
        DateTimeStart = meta.TimeStamp;

        Console.WriteLine(e);
    }

    private void OnEvent(GameSavedEvent e, EventMetadata meta)
    {
        Console.WriteLine(e);
    }

    private void OnEvent(GameTerminatedEvent e, EventMetadata meta)
    {
        DateTimeEnd = meta.TimeStamp;

        Console.WriteLine(e);
    }

    public override string ToString()
    {
        return $"DateTimeStart: {DateTimeStart}, DateTimeEnd: {DateTimeEnd}";
    }
}