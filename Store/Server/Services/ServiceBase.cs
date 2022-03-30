using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Store.Server.Services;

internal abstract class ServiceBase<TContext> where TContext: DbContext
{
    protected internal IDbContextFactory<TContext> Context { get; init; }
    protected internal IMemoryCache? Cache { get; init; }

    protected ServiceBase(IDbContextFactory<TContext> context, IMemoryCache cache)
    {
        Context = context;
        Cache = cache;
    }
}
