using System.ComponentModel.DataAnnotations;

namespace Store.Data;

public class Badge
{
    public string Id { get; set; } = string.Empty;

    [StringLength(32, MinimumLength = 2)]
    public string Title { get; set; } = string.Empty;

    [Url]
    public Uri Url { get; set; } = default!;

    [MaxLength(255)]
    public string? Image { get; set; }

    public int SortOrder { get; set; }
    public bool Enabled { get; set; }
}
