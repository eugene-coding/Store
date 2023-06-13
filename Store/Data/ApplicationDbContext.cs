using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Store.Data;

/// <summary>
/// Database context.
/// </summary>
public class ApplicationDbContext : IdentityDbContext
{
    /// <summary>
    /// Creates the <see cref="ApplicationDbContext"/> instance.
    /// </summary>
    /// <param name="options">Options for configuring the <see cref="ApplicationDbContext"/></param>
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
