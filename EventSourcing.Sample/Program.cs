using EventSourcing.Library;
using EventSourcing.Sample.Events;
using EventSourcing.Sample.Persistence;

namespace EventSourcing.Sample;

class Program
{
    static void Main(string[] args)
    {
        using (var dbContext = new AppDbContext())
        {
            Guid streamId = Guid.NewGuid();

            dbContext.Events.AppendEvent(new GameStartedEvent(), streamId);
            dbContext.Events.AppendEvent(new GameSavedEvent(), streamId);
            dbContext.Events.AppendEvent(new GameSavedEvent(), streamId);
            dbContext.Events.AppendEvent(new GameSavedEvent(), streamId);
            dbContext.Events.AppendEvent(new GameTerminatedEvent(), streamId);

            dbContext.SaveChanges();

            var aggregate = dbContext.Events.AggregateEvents<GameAggregate>(streamId);

            Console.WriteLine(aggregate);
        }
    }
}