using Microsoft.EntityFrameworkCore;
using TicketFlow.Api.Models;

namespace TicketFlow.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Ticket> Tickets => Set<Ticket>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ticket>(e =>
        {
            e.Property(t => t.Title).IsRequired().HasMaxLength(200);
            e.Property(t => t.Status).HasConversion<string>();
            e.Property(t => t.Priority).HasConversion<string>();
        });
    }
}