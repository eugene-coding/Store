using Microsoft.EntityFrameworkCore;

namespace Store.Data.Models;

/// <summary>
/// A database entry describing an attribute.
/// </summary>
[Comment("Contains attributes.")]
public class Attribute
{
    /// <summary>
    /// Attribute ID.
    /// </summary>
    [Comment("Attribute ID.")]
    public int Id { get; set; }

    /// <summary>
    /// The ID of the <see cref="Models.AttributeGroup"/> this entry belongs.
    /// </summary>
    [Comment("The ID of the attribute group this entry belongs.")]
    public int AttributeGroupId { get; set; }

    /// <summary>
    /// Attribute sort order.
    /// </summary>
    [Comment("Attribute sort order.")]
    public int SortOrder { get; set; }

    /// <summary>
    /// The foreign key to the <see cref="Models.AttributeGroup"/> this entry belongs.
    /// </summary>
    public AttributeGroup? AttributeGroup { get; set; }
}
