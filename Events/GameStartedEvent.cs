namespace Project.Events;

public sealed class GameStartedEvent : EventBase
{
    // Starting position of the player
    public Position Position { get; } = PositionGenerator.Get();
}