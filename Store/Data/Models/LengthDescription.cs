using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Store.Data.Models;

[PrimaryKey(nameof(LengthId), nameof(LanguageId))]
public class LengthDescription
{
    public int LengthId { get; set; }
    public int LanguageId { get; set; }

    [MaxLength(32)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(4)]
    public string Unit { get; set; } = string.Empty;

    public virtual Length? Length { get; set; }
    public virtual Language? Language { get; set; }
}
