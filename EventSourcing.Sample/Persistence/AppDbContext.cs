using EventSourcing.Library;
using Microsoft.EntityFrameworkCore;

namespace EventSourcing.Sample.Persistence;

public sealed class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("in_memory");
    }

    public DbSet<Event> GameEvents { get; init; } = null!;
}