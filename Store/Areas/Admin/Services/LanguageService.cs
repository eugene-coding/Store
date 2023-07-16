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

    public async Task AddAsync(Language language)
    {
        _context.Languages.Add(language);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(LanguageView language)
    {
        var entity = await _context.Languages.FindAsync(language.Id);

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
        var language = await _context.Languages.FindAsync(id);

        if (language is not null)
        {
            _context.Languages.Remove(language);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<LanguageView?> GetAsync(int id)
    {
        return await _context.Languages
            .Where(language => language.Id == id)
            .Cast<LanguageView>()
            .SingleOrDefaultAsync();
    }

    public async Task<List<LanguageView>> GetAsync()
    {
        return await _context.Languages
            .Select(language => (LanguageView) language)
            .ToListAsync();
    }

    public async Task<bool> ExistsAsync(string code)
    {
        return await _context.Languages.AnyAsync(l => l.Code == code);
    }

    public async Task<int> GetCountAsync()
    {
        return await _context.Languages.CountAsync();
    }
}
