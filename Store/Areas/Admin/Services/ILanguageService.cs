using Store.Data;
using Store.Data.Models;

namespace Store.Areas.Admin.Services;

/// <summary>
/// Provides methods for working with the <see cref="ApplicationDbContext.Languages"/> table.
/// </summary>
public interface ILanguageService
{
    /// <summary>
    /// Adds a new <see cref="Language"/>.
    /// </summary>
    /// <param name="language">Language.</param>
    Task AddAsync(Language language);

    /// <summary>
    /// Checks if a <see cref="Language"/> with the specified <paramref name="code"/> exists.
    /// </summary>
    /// <param name="code">Language code.</param>
    /// <returns>
    /// Returns <see langword="true"/> if the <see cref="Language"/> with the specified <paramref name="code"/> exists, 
    /// otherwise - <see langword="false"/>.
    /// </returns>
    Task<bool> ExistsAsync(string code);

    /// <summary>
    /// Returns the number of <see cref="Language"/>.
    /// </summary>
    /// <returns>Number of <see cref="Language"/>.</returns>
    Task<int> GetCountAsync();
}
