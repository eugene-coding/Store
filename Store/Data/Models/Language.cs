using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Store.Data.Models;

/// <summary>
/// A database entry describing the available language.
/// </summary>
[Index(nameof(Code), IsUnique = true)]
[Comment("Contains the available languages.")]
public class Language
{
    public Language() 
    { 
    }

    [SetsRequiredMembers]
    public Language(string code)
    {
        Code = code;
    }

    /// <summary>
    /// Language ID.
    /// </summary>
    [Comment("Language ID.")]
    public int Id { get; set; }

    /// <summary>
    /// Language code.
    /// </summary>
    [MaxLength(5)]
    [Comment("Language code.")]
    public required string Code { get; set; }
}
