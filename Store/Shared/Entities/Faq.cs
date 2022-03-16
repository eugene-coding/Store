using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Shared.Entities;

[Table("faq")]
public class Faq
{
    public int Id { get; init; }
    public string Question { get; init; } = null!;
    public string AnswerBody { get; init; } = null!;
    public string? AnswerFooter { get; init; }

    public bool ShowInFaqBlock { get; init; }

    public int SortOrder { get; init; }
    public bool Enabled { get; init; }
}
