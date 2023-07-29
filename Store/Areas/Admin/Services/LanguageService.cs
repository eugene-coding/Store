using Microsoft.EntityFrameworkCore;

using Store.Areas.Admin.Pages.Localization.Language;
using Store.Data;
using Store.Data.Models;
using System.Linq.Dynamic.Core;

namespace Store.Areas.Admin.Services;

/// <inheritdoc cref="ILanguageService"/>
public class LanguageService : ILanguageService
{
    private readonly ApplicationDbContext _context;

    /// <summary>
    /// Creates the <see cref="LanguageService"/> instance.
    /// </summary>
    /// <param name="context">Database context.</param>
    public LanguageService(ApplicationDbContext context)
    {
        _context = context;
    }

    private DbSet<Language> Languages => _context.Languages;

    public async Task AddAsync(Language language)
    {
        Languages.Add(language);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(LanguageView language)
    {
        var entity = await Languages.FindAsync(language.Id);

        if (entity is not null)
        {
            entity.Name = language.Name;
            entity.Code = language.Code;
            entity.SortOrder = language.SortOrder;
            entity.Enabled = language.Enabled;

            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(IReadOnlyCollection<int> ids)
    {
        if (ids.Count > 0)
        {
            var languages = await _context.Languages
                .Where(a => ids.Contains(a.Id))
                .ToArrayAsync();

            _context.Languages.RemoveRange(languages);

            await _context.SaveChangesAsync();
        }
    }

    public async Task<LanguageView?> GetAsync(int id)
    {
        return await Languages
            .Where(language => language.Id == id)
            .Cast<LanguageView>()
            .AsNoTracking()
            .SingleOrDefaultAsync();
    }

    public async Task<List<LanguageView>> GetAsync()
    {
        return await Languages
            .Cast<LanguageView>()
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<LanguageView>> GetAsync(string sort)
    {
        var query = Languages.AsQueryable();

        if (!string.IsNullOrEmpty(sort))
        {
            query = query.OrderBy(sort);
        }

        return await query
            .Cast<LanguageView>()
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<string?> GetCodeAsync(int id)
    {
        return await Languages
            .Where(language => language.Id == id)
            .Select(language => language.Code)
            .SingleOrDefaultAsync();
    }

    public async Task<bool> ExistsAsync(string code)
    {
        return await Languages.AnyAsync(l => l.Code == code);
    }

    public async Task<int> GetCountAsync()
    {
        return await Languages.CountAsync();
    }
}
