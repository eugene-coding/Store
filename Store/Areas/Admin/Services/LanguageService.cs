using Microsoft.EntityFrameworkCore;

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

    public async Task<bool> ExistsAsync(string code)
    {
        return await _context.Languages.AnyAsync(l => l.Code == code);
    }

    public async Task<int> GetCountAsync()
    {
        return await _context.Languages.CountAsync();
    }
}
