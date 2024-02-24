using EventSourcing.Library;

namespace EventSourcing.Sample.Events;

public sealed class GameSavedEvent : EventBase
{
    public int Points { get; } = 10;
}