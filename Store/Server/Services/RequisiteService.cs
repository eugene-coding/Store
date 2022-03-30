using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

using Store.Server.Data;
using Store.Shared.Entities;

namespace Store.Server.Services;

internal sealed class RequisiteService : ServiceBase<Context>, IRequisiteService
{
    public RequisiteService(IDbContextFactory<Context> context, IMemoryCache cache) : base(context, cache)
    {
    }

    public async Task<IReadOnlyCollection<Requisite>> GetAsync()
    {
        IReadOnlyCollection<Requisite> requisites;
        string cacheKey = nameof(requisites);

        if (!Cache.TryGetValue(cacheKey, out requisites))
        {
            using (var context = Context.CreateDbContext())
            {
                requisites = await context.Requisites
                    .Where(requisite => requisite.Enabled)
                    .OrderBy(requisite => requisite.SortOrder)
                    .ToListAsync();
            }

            Cache.Set(cacheKey, requisites, new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(5)));
        }

        return requisites;
    }
}
