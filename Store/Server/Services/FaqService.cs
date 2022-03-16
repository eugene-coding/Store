using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

using Store.Server.Data;
using Store.Shared.Entities;

namespace Store.Server.Services;

internal sealed class FaqService : ServiceBase<Context>, IFaqService
{
    public FaqService(IDbContextFactory<Context> context, IMemoryCache cache) : base(context, cache)
    {
    }

    public async Task<IReadOnlyCollection<Faq>> GetAsync()
    {
        IReadOnlyCollection<Faq> faq;

        if (!Cache.TryGetValue(nameof(faq), out faq))
        {
            using (var context = Context.CreateDbContext())
            {
                faq = await context.Faq
                    .Where(faq => faq.Enabled)
                    .OrderBy(faq => faq.SortOrder)
                    .ToListAsync();
            }

            Cache.Set(nameof(faq), faq, new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(5)));
        }

        return faq;
    }

    public async Task<IReadOnlyCollection<Faq>> GetForBlockAsync(int count)
    {
        IReadOnlyCollection<Faq> faq;
        string cacheKey = $"{nameof(faq)}-block";

        if (!Cache.TryGetValue(cacheKey, out faq))
        {
            using (var context = Context.CreateDbContext())
            {
                faq = await context.Faq
                    .Where(faq => faq.Enabled && faq.ShowInFaqBlock)
                    .Take(count)
                    .ToListAsync();
            }

            Cache.Set(cacheKey, faq, new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(5)));
        }

        return faq;
    }
}
