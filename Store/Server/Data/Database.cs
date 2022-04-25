using Microsoft.EntityFrameworkCore;

using Store.Shared.Models;

namespace Store.Server.Data;

public class Database : DbContext
{
    public Database(DbContextOptions<Database> options) : base(options) 
    {
    }

    public DbSet<Badge> Badges => Set<Badge>();
    public DbSet<Social> Socials => Set<Social>();
}
