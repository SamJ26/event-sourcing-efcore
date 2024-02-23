namespace Project;

public abstract class AggregateBase
{
    public Guid StreamId { get; private set; }

    public abstract void Apply(EventBase e, EventMetadata eventMeta);
}