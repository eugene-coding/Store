using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;

namespace Store.Data.Models;

/// <summary>
/// A database entry describing the available language.
/// </summary>
[Index(nameof(Code), IsUnique = true)]
[Comment("Contains the available languages.")]
public class Language
{
    /// <summary>
    /// Language ID.
    /// </summary>
    [Comment("Language ID.")]
    public int Id { get; set; }

    /// <summary>
    /// Language name.
    /// </summary>
    [MaxLength(32)]
    [Comment("Language name.")]
    public required string Name { get; set; }

    /// <summary>
    /// Language code.
    /// </summary>
    [MaxLength(5)]
    [Comment("Language code.")]
    public required string Code { get; set; }

    /// <summary>
    /// Sort order.
    /// </summary>
    [Comment("Sort order.")]
    public int SortOrder { get; set; }

    /// <summary>
    /// Determines if the <see cref="Language"/> is enabled, whether it should be displayed in the lists of available languages.
    /// </summary>
    [Comment("Determines if the language is enabled, whether it should be displayed in the lists of available languages.")]
    public bool Enabled { get; set; }
}
