using System.ComponentModel.DataAnnotations;

namespace Store.Shared.Models;

public sealed class Badge
{
    public int Id { get; set; }

    [StringLength(32, MinimumLength = 2)]
    public string Title { get; set; } = string.Empty;

    [Url]
    public Uri Url { get; set; } = default!;

    [MaxLength(255)]
    public string Image { get; set; } = string.Empty;
    public ushort Width { get; set; }
    public ushort Height { get; set; }

    public int SortOrder { get; set; }
    public bool Enabled { get; set; }
}
