using Microsoft.EntityFrameworkCore;

using Store.Areas.Admin.Pages.Localization.Language;
using Store.Data;
using Store.Data.Models;

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

    public async Task DeleteAsync(int id)
    {
        var language = await Languages.FindAsync(id);

        if (language is not null)
        {
            _context.Languages.Remove(language);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<LanguageView?> GetAsync(int id)
    {
        return await Languages
            .Where(language => language.Id == id)
            .Cast<LanguageView>()
            .SingleOrDefaultAsync();
    }

    public async Task<List<LanguageView>> GetAsync()
    {
        return await Languages
            .Cast<LanguageView>()
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
