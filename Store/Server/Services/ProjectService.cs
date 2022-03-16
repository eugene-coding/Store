using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

using Store.Server.Data;
using Store.Shared.Entities;

namespace Store.Server.Services;

internal sealed class ProjectService : ServiceBase<Context>, IProjectService
{
    public ProjectService(IDbContextFactory<Context> context, IMemoryCache cache) : base(context, cache)
    {
    }

    public async Task<Project?> GetAsync(string seo)
    {
        string cacheKey = $"project-{seo}";

        if (!Cache.TryGetValue(cacheKey, out Project? project))
        {
            using (Context context = Context.CreateDbContext())
            {
                var enabled = await context.Projects
                    .Where(project => project.Seo == seo)
                    .Select(project => project.Enabled)
                    .SingleOrDefaultAsync();

                if (enabled)
                {
                    project = await context.Projects
                        .Include(project => project.Images
                            .Where(image => image.Enabled)
                            .OrderBy(image => image.SortOrder)
                        )
                        .Where(project => project.Seo == seo)
                        .SingleOrDefaultAsync();
                }
            }

            Cache.Set(cacheKey, project, new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(5)));
        }

        return project;
    }

    public async Task<IReadOnlyList<Project>> GetAsync()
    {
        string cacheKey = "projects";

        if (!Cache.TryGetValue(cacheKey, out IReadOnlyList<Project> projects))
        {
            using (Context context = Context.CreateDbContext())
            {
                projects = await context.Projects
                                        .Include(project => project.Images
                                            .Where(image => image.Enabled)
                                            .OrderBy(image => image.SortOrder)
                                        )
                                        .Where(project => project.Enabled)
                                        .OrderBy(project => project.SortOrder)
                                        .ThenBy(project => project.PublishedTime)
                                        .ToListAsync();
            }

            Cache.Set(cacheKey, projects, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
        }

        return projects;
    }

    public async Task<IReadOnlyList<Project>> GetWithoutImagesAsync(int count, int skip = 0)
    {
        using Context context = Context.CreateDbContext();

        IQueryable<Project> projects = context.Projects
                                        .Where(project => project.Enabled)
                                        .OrderBy(project => project.SortOrder)
                                        .ThenBy(project => project.PublishedTime);

        if (skip > 0)
        {
            projects = projects.Skip(skip);
        }

        return await projects.Take(count).ToListAsync();
    }

    public async Task<int> GetCountAsync()
    {
        string cacheKey = "projects-count";

        if (!Cache.TryGetValue(cacheKey, out int count))
        {
            using (Context context = Context.CreateDbContext())
            {
                count = await context.Projects
                                        .Where(project => project.Enabled)
                                        .CountAsync();
            }

            Cache.Set(cacheKey, count, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
        }

        return count;
    }
}
