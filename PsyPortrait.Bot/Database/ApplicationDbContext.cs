using Microsoft.EntityFrameworkCore;
using PsyPortrait.Bot.Entities;

namespace PsyPortrait.Bot.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /*modelBuilder.Entity<Person>(builder =>
            builder.OwnsOne(a => a.Tags, tagsBuilder => tagsBuilder.ToJson()));*/
    }

    public DbSet<Person> Articles { get; set; }
}
