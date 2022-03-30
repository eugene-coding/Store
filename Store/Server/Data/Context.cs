using Microsoft.EntityFrameworkCore;

using Store.Shared.Entities;

namespace Store.Server.Data;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options) { }

    public DbSet<Project> Projects => Set<Project>();
    public DbSet<Faq> Faq => Set<Faq>();
    public DbSet<Requisite> Requisites => Set<Requisite>();
    public DbSet<Social> Socials => Set<Social>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        var project = builder.Entity<Project>();
        project
            .HasIndex(project => project.Seo)
            .IsUnique();
        project
            .Property(project => project.SortOrder)
            .HasDefaultValue(0);

        var requisite = builder.Entity<Requisite>();
        requisite
            .HasIndex(requisite => requisite.Key)
            .IsUnique();
        requisite
            .Property(requisite => requisite.SortOrder)
            .HasDefaultValue(0);

        var social = builder.Entity<Social>();
        social
            .HasIndex(requisite => requisite.Key)
            .IsUnique();
        social
            .Property(requisite => requisite.SortOrder)
            .HasDefaultValue(0);
    }
}
