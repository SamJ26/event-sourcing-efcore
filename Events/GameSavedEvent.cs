using Project.EventSourcing;

namespace Project.Events;

public sealed class GameSavedEvent : EventBase
{
    public int Points { get; } = 10;
}