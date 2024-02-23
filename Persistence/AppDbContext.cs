using Microsoft.EntityFrameworkCore;
using Project.EventSourcing;

namespace Project.Persistence;

public sealed class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("in_memory");
    }

    public DbSet<EventEntity> GameEvents { get; init; } = null!;
}