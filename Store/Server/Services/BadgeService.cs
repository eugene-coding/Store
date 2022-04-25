using Microsoft.EntityFrameworkCore;

using Store.Server.Data;
using Store.Shared.Models;
using Store.Shared.Services;

namespace Store.Server.Services;

internal sealed class BadgeService : ServiceBase<Database>, IBadgeService
{
    public BadgeService(IDbContextFactory<Database> database) : base(database)
    {
    }

    public async Task<IEnumerable<Badge>> GetNoTrackingAsync()
    {
        using var context = await Database.CreateDbContextAsync();

        return await context.Badges
            .Where(badge => badge.Enabled)
            .OrderBy(badge => badge.SortOrder)
            .AsNoTracking()
            .ToListAsync();
    }
}
