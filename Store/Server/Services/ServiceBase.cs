using Microsoft.EntityFrameworkCore;

namespace Store.Server.Services;

internal abstract class ServiceBase<TContext> where TContext : DbContext
{
    protected ServiceBase(IDbContextFactory<TContext> database)
    {
        Database = database;
    }

    protected IDbContextFactory<TContext> Database { get; init; }
}
