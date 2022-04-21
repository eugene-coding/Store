using Microsoft.EntityFrameworkCore;

namespace Store.Data;

public class Database : DbContext
{
    public Database(DbContextOptions<Database> options) : base(options) { }

    public DbSet<Social> Socials => Set<Social>();
    public DbSet<Badge> Badges => Set<Badge>();
}
