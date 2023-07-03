using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;

namespace Store.Data.Models;

/// <summary>
/// A database entry containing a description of an <see cref="Models.Attribute/>.
/// </summary>
[PrimaryKey(nameof(AttributeId), nameof(LanguageId))]
[Comment("Contains descriptions for attributes.")]
public class AttributeDescription
{
    /// <summary>
    /// The ID of the <see cref="Models.Attribute"/> this entry describes.
    /// </summary>
    [Comment("The ID of the attribute this entry describes.")]
    public int AttributeId { get; set; }

    /// <summary>
    /// The ID of the <see cref="Models.Language"/> in which this entry is written.
    /// </summary>
    [Comment("The ID of the language in which this entry is written.")]
    public int LanguageId { get; set; }

    /// <summary>
    /// Attribute group name.
    /// </summary>
    [MaxLength(64)]
    [Comment("Attribute name.")]
    public required string Name { get; set; }

    /// <summary>
    /// The foreign key to the <see cref="Models.Attribute"/> this entry describes.
    /// </summary>
    public Attribute? Attribute { get; set; }

    /// <summary>
    /// Foreign key to the <see cref="Models.Language"/> in which this entry is written.
    /// </summary>
    public Language? Language { get; set; }
}