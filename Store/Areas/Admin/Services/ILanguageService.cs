using Store.Areas.Admin.Pages.Localization.Language;
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
    /// Finds the <see cref="Language"/> entry by <see cref="LanguageView.Id"/> 
    /// and updates its values.
    /// </summary>
    /// <param name="language">Language view.</param>
    Task UpdateAsync(LanguageView language);

    /// <summary>
    /// Removes the <see cref="Language"/> with the specified <paramref name="id"/>.
    /// </summary>
    /// <param name="id">Language ID</param>
    Task DeleteAsync(int id);

    Task DeleteAsync(IReadOnlyCollection<int> ids);

    /// <summary>
    /// Returns the <see cref="Language"/> with the specified <paramref name="id"/> converted to <see cref="LanguageView"/>.
    /// </summary>
    /// <returns>
    /// The <see cref="Language"/> with the specified <paramref name="id"/> converted to <see cref="LanguageView"/>, 
    /// if such a <see cref="Language"/> exists, otherwise - <see langword="null"/></returns>
    Task<LanguageView?> GetAsync(int id);

    /// <summary>
    /// Returns a <see cref="List{T}"/> of <see cref="Language"/> converted to <see cref="LanguageView"/>.
    /// </summary>
    /// <returns><see cref="List{T}"/> of <see cref="Language"/> converted to <see cref="LanguageView"/>.</returns>
    Task<List<LanguageView>> GetAsync();

    /// <summary>
    /// Returns a <see cref="List{T}"/> of <see cref="Language"/> converted to <see cref="LanguageView"/> sorted by <paramref name="sort"/>.
    /// </summary>
    /// <param name="sort">Column name to sort by.</param>
    /// <returns>
    /// <see cref="List{T}"/> of <see cref="Language"/> converted to <see cref="LanguageView"/> sorted by <paramref name="sort"/>.
    /// </returns>
    Task<List<LanguageView>> GetAsync(string sort);

    /// <summary>
    /// Returns the <see cref="Language.Code"/> of the <see cref="Language"/> with the specified <paramref name="id"/>.
    /// </summary>
    /// <returns>
    /// The <see cref="Language.Code"/> of the <see cref="Language"/> with the specified <paramref name="id"/>, 
    /// if such a <see cref="Language"/> exists, otherwise - <see langword="null"/></returns>
    Task<string?> GetCodeAsync(int id);

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
