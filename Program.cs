using Project.Events;

namespace Project;

class Program
{
    static void Main(string[] args)
    {
        var eventStorage = new EventStorage();

        Guid streamId = Guid.NewGuid();

        eventStorage.AddEvent(new GameStartedEvent(), streamId);
        eventStorage.AddEvent(new GameSavedEvent(), streamId);
        eventStorage.AddEvent(new GameSavedEvent(), streamId);
        eventStorage.AddEvent(new GameSavedEvent(), streamId);
        eventStorage.AddEvent(new GameTerminatedEvent(), streamId);

        var aggregate = eventStorage.Aggregate<GameAggregate>(streamId);

        Console.WriteLine(aggregate);
    }
}