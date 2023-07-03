using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;

namespace Store.Data.Models;

/// <summary>
/// A database entry containing a description of an <see cref="Models.AttributeGroup"/>.
/// </summary>
[PrimaryKey(nameof(AttributeGroupId), nameof(LanguageId))]
[Comment("Contains descriptions for attribute groups.")]
public class AttributeGroupDescription
{
    /// <summary>
    /// The ID of the <see cref="Models.AttributeGroup"/> this entry describes.
    /// </summary>
    [Comment("The ID of the attribute group this entry describes.")]
    public int AttributeGroupId { get; set; }

    /// <summary>
    /// The ID of the <see cref="Models.Language"/> in which this entry is written.
    /// </summary>
    [Comment("The ID of the language this entry describes.")]
    public int LanguageId { get; set; }

    /// <summary>
    /// Attribute group name.
    /// </summary>
    [MaxLength(64)]
    [Comment("Attribute group name.")]
    public required string Name { get; set; }

    /// <summary>
    /// The foreign key to the <see cref="Models.AttributeGroup"/> this entry describes.
    /// </summary>
    public AttributeGroup? AttributeGroup { get; set; }

    /// <summary>
    /// Foreign key to the <see cref="Models.Language"/> in which this entry is written.
    /// </summary>
    public Language? Language { get; set; }
}
