using AquaPP.Models;
using Microsoft.EntityFrameworkCore;

namespace AquaPP.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<ChatMessage> ChatMessages { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}
