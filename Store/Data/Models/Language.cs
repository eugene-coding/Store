using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;

namespace Store.Data.Models;

/// <summary>
/// A database entry describing the available language.
/// </summary>
[Index(nameof(Name))]
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
}
