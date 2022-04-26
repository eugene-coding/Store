using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

using Store.Data;

namespace Store.Services;

internal class SocialService : ServiceBase<Database>, ISocialService
{
    public SocialService(IDbContextFactory<Database> database, IMemoryCache cache) : base(database, cache) { }

    public async Task<IReadOnlyCollection<Social>> GetNoTrackingAsync()
    {
        //var cacheKey = "socials";
        var cachingTime = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(5));

        //if (!Cache.TryGetValue(cacheKey, out IReadOnlyCollection<Social> socials))
        //{
            using (var context = Database.CreateDbContext())
            {
                //socials = await context.Socials.ToListAsync();
                return await context.Socials.AsNoTracking().ToListAsync();
            }

            //Cache.Set(cacheKey, socials, cachingTime);
        //}

        //return socials;
    }
}
