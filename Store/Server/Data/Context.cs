using Microsoft.EntityFrameworkCore;

using Store.Shared.Entities;

namespace Store.Server.Data;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options) { }

    public DbSet<Project> Projects => Set<Project>();
    public DbSet<Faq> Faq => Set<Faq>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        var project = builder.Entity<Project>();
        
        project
            .HasIndex(project => project.Seo)
            .IsUnique();

        project
            .Property(project => project.SortOrder)
            .HasDefaultValue(0);
    }
}
