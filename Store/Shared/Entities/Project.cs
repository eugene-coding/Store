using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Shared.Entities;

[Table("project")]
public class Project
{
    public int Id { get; set; }

    [StringLength(150, MinimumLength = 1)]
    public string Name { get; set; } = string.Empty;
    public string? Image { get; set; }
    public ICollection<ProjectImage> Images { get; set; } = null!;

    public string? Location { get; set; }

    public string? Content { get; set; }
    public string? Description { get; set; }

    [StringLength(150, MinimumLength = 1)]
    public string Seo { get; set; } = null!;

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime ModifiedTime { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime PublishedTime { get; set; }
    
    public int SortOrder { get; set; }
    public bool Enabled { get; set; }
}
