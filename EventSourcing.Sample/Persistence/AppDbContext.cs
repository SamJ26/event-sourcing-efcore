using EventSourcing.Library;
using Microsoft.EntityFrameworkCore;

namespace EventSourcing.Sample.Persistence;

public sealed class AppDbContext : EventSourcingDbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("");
    }
}