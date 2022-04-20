using Microsoft.EntityFrameworkCore;

namespace Store.Data;

public class Database : DbContext
{
    public DbSet<Social> Socials => Set<Social>();
}
