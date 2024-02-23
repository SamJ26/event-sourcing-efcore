namespace Project.Events;

public sealed class GameSavedEvent : EventBase
{
    // Current position of the player
    public Position Position { get; } = PositionGenerator.Get();
}