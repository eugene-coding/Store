using Microsoft.EntityFrameworkCore;

namespace Store.Data.Models;

/// <summary>
/// A database entry describing an attribute group.
/// </summary>
[Comment("Contains attribute groups.")]
public class AttributeGroup
{
    /// <summary>
    /// Attribute group ID.
    /// </summary>
    [Comment("Attribute group ID.")]
    public int Id { get; set; }

    /// <summary>
    /// Attribute group sort order.
    /// </summary>
    [Comment("Attribute group sort order.")]
    public int SortOrder { get; set; }

    /// <summary>
    /// Foreign key to entries describing this <see cref="AttributeGroup"/>.
    /// </summary>
    public List<AttributeGroupDescription>? Descriptions { get; set; }
}
