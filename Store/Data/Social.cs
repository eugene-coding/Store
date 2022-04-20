using System.ComponentModel.DataAnnotations;

namespace Store.Data;

public class Social
{
    public Social(string name, Uri uri)
    {
        Name = name;
        Uri = uri;
    }

    [Key]
    [StringLength(32, MinimumLength = 2)]
    public string Name { get; set; }

    public Uri Uri { get; set; }
    public int SortOrder { get; set; }
    public bool Enabled { get; set; }
}
