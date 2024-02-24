using Microsoft.EntityFrameworkCore;

namespace EventSourcing.Library;

public class EventSourcingDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.StreamId);
            entity.ToTable("events");

            entity
                .Property(x => x.Id)
                .HasColumnName("id");

            entity
                .Property(x => x.StreamId)
                .HasColumnName("stream_id");

            entity
                .Property(x => x.TimeStamp)
                .HasColumnName("time_stamp");

            entity
                .Property(x => x.DataType)
                .HasColumnName("data_type");

            entity
                .Property(x => x.Data)
                .HasColumnName("data");
        });
    }

    public DbSet<Event> Events { get; init; } = null!;
}