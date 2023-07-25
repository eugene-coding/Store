using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Store.Data.Models;

/// <summary>
/// Database entry describing one of the site settings.
/// </summary>
[Comment("Contains site settings.")]
public class Setting
{
    [SetsRequiredMembers]
    public Setting(string key, int value)
    {
        Key = key;
        Value = value.ToString();
    }

    /// <summary>
    /// Setting ID.
    /// </summary>
    [Comment("Setting ID.")]
    public int Id { get; set; }

    /// <summary>
    /// Setting name.
    /// </summary>
    [MaxLength(128)]
    [Comment("Setting name.")]
    public required string Key { get; set; }

    /// <summary>
    /// Setting value.
    /// </summary>
    [Comment("Setting value.")]
    public required string Value { get; set; }
}
