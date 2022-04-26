using System.ComponentModel.DataAnnotations;

namespace Store.Data;

public class Social
{
    public int Id { get; set; }

    [StringLength(32, MinimumLength = 2)]
    public string Title { get; set; } = string.Empty;

    [Url]
    public Uri Url { get; set; } = default!;

    [MaxLength(255)]
    public string? Icon { get; set; }

    public int SortOrder { get; set; }
    public bool Enabled { get; set; }
}
