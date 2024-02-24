using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace Project.EventSourcing;

public static class DbSetExtensions
{
    public static void AppendEvent(this DbSet<Event> dbSet, EventBase e, Guid streamId)
    {
        dbSet.Add(new Event()
        {
            TimeStamp = DateTime.UtcNow,
            StreamId = streamId,
            Data = e.Serialize(),
            DataType = e.GetRuntimeType()
        });
    }
    
    public static TAggregate AggregateEvents<TAggregate>(this DbSet<Event> dbSet, Guid streamId) where TAggregate : AggregateBase, new()
    {
        var agg = new TAggregate();

        foreach (var e in dbSet)
        {
            var eventDataType = Type.GetType(e.DataType);
            if (eventDataType is null)
            {
                throw new Exception($"Event type with name '{e.DataType}' does not exists.");
            }

            var eventInstance = JsonSerializer.Deserialize(e.Data, eventDataType) as EventBase;
            if (eventInstance is null)
            {
                throw new Exception($"Unable to create instance of a type '{nameof(eventDataType)}'.");
            }

            var eventMeta = new EventMetadata()
            {
                StreamId = e.StreamId,
                TimeStamp = e.TimeStamp
            };

            agg.Apply(eventInstance, eventMeta);
        }

        return agg;
    }
}