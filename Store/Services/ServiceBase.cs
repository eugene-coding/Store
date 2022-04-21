using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Store.Services;

internal abstract class ServiceBase<TContext> where TContext : DbContext
{
    protected ServiceBase(IDbContextFactory<TContext> database)
    {
        Database = database;
    }

    protected ServiceBase(IDbContextFactory<TContext> context, IMemoryCache cache) : this(context)
    {
        Cache = cache;
    }

    protected internal IDbContextFactory<TContext> Database { get; init; }
    protected internal IMemoryCache? Cache { get; init; }
}
