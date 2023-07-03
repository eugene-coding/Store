using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Store.Data.Models;

namespace Store.Data;

/// <summary>
/// Database context.
/// </summary>
public class ApplicationDbContext : IdentityDbContext
{
    /// <summary>
    /// Creates the <see cref="ApplicationDbContext"/> instance.
    /// </summary>
    /// <param name="options">Options for configuring the <see cref="ApplicationDbContext"/>.</param>
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Attribute group table.
    /// </summary>
    public DbSet<AttributeGroup> AttributeGroups { get; set; }

    /// <summary>
    /// Attribute group description table.
    /// </summary>  
    public DbSet<AttributeGroupDescription> AttributeGroupDescriptions { get; set; }

    /// <summary>
    /// Table with available languages.
    /// </summary>
    public DbSet<Language> Languages { get; set; }
}
