using Microsoft.EntityFrameworkCore;

using Store.Server.Data;
using Store.Shared.Models;
using Store.Shared.Services;

namespace Store.Server.Services;

internal sealed class SocialService : ServiceBase<Database>, ISocialService
{
    public SocialService(IDbContextFactory<Database> database) : base(database)
    {
    }

    public async Task<IEnumerable<Social>> GetNoTrackingAsync()
    {
        using var context = await Database.CreateDbContextAsync();

        return await context.Socials
            .Where(social => social.Enabled)
            .OrderBy(social => social.SortOrder)
            .AsNoTracking()
            .ToListAsync();
    }
}
