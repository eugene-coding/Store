using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

using Store.Client.Shared.Common;
using Store.Server.Data;
using Store.Shared.Entities;

namespace Store.Server.Services;

internal sealed class SocialService : ServiceBase<Context>, ISocialService
{
    public SocialService(IDbContextFactory<Context> context, IMemoryCache cache) : base(context, cache)
    {
    }

    public async Task<IReadOnlyCollection<Shared.Entities.Social>> GetAsync()
    {
        //IReadOnlyCollection<Social> socials;
        //string cacheKey = nameof(socials);

        //if (!Cache.TryGetValue(cacheKey, out socials))
        //{
        //    using (var context = Context.CreateDbContext())
        //    {
        //        socials = await context.Socials
        //            .Where(requisite => requisite.Enabled)
        //            .OrderBy(requisite => requisite.SortOrder)
        //            .ToListAsync();
        //    }

        //    Cache.Set(cacheKey, socials, new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(5)));
        //}

        //return socials;

        using (var context = Context.CreateDbContext())
{
           var s = await context.Socials
                .Where(requisite => requisite.Enabled)
                .OrderBy(requisite => requisite.SortOrder)
                .ToListAsync();

            return (IReadOnlyCollection<Shared.Entities.Social>)s;
        }
    }
}
