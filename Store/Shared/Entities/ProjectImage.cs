using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Store.Shared.Entities;

[Table("project-image")]
public class ProjectImage
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public string Url { get; set; } = null!;

    public int SortOrder { get; set; }
    public bool Enabled { get; set; }

    [JsonIgnore]
    public Project? Project { get; set; }
}
