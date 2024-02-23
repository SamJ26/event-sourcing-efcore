﻿using Project.Events;
using Project.Persistence;
using Project.EventSourcing;

namespace Project;

class Program
{
    static void Main(string[] args)
    {
        using (var dbContext = new AppDbContext())
        {
            Guid streamId = Guid.NewGuid();
            
            dbContext.GameEvents.AppendEvent(new GameStartedEvent(), streamId);
            dbContext.GameEvents.AppendEvent(new GameSavedEvent(), streamId);
            dbContext.GameEvents.AppendEvent(new GameSavedEvent(), streamId);
            dbContext.GameEvents.AppendEvent(new GameSavedEvent(), streamId);
            dbContext.GameEvents.AppendEvent(new GameTerminatedEvent(), streamId);

            dbContext.SaveChanges();
            
            var aggregate = dbContext.GameEvents.AggregateEvents<GameAggregate>(streamId);
            
            Console.WriteLine(aggregate);
        }
    }
}