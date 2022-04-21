using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

using Store.Data;

namespace Store.Services;

internal class BadgeService : ServiceBase<Database>, IBadgeService
{
    public BadgeService(IDbContextFactory<Database> database, IMemoryCache cache) : base(database, cache)
    {
    }

    public async Task<IReadOnlyCollection<Badge>> GetNoTrackingAsync()
    {
        using var context = Database.CreateDbContext();

        return await context.Badges.AsNoTracking().ToListAsync();
    }
}
