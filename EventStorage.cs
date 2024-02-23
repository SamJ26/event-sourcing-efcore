using System.Text;
using System.Text.Json;

namespace Project;

public sealed class EventStorage
{
    private int _idCounter = 0;
    private readonly List<EventStorageModel> _events = new();

    public IEnumerable<EventStorageModel> Events => _events.AsEnumerable();

    public void AddEvent(EventBase e, Guid streamId)
    {
        _events.Add(new EventStorageModel()
        {
            Id = _idCounter++,
            TimeStamp = DateTime.UtcNow,
            StreamId = streamId,
            Data = e.Serialize(),
            DataType = e.GetRuntimeType()
        });
    }

    public string GetDebugView()
    {
        var sb = new StringBuilder();

        foreach (var e in _events)
        {
            sb.AppendLine(e.ToString());
        }

        return sb.ToString();
    }

    public TAggregate Aggregate<TAggregate>(Guid streamId) where TAggregate : AggregateBase, new()
    {
        var agg = new TAggregate();

        foreach (var e in _events)
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