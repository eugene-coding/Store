namespace Store.Client.Shared.Templates;

public partial class FaqList
{
    [Parameter]
    public IReadOnlyCollection<Faq> Items { get; init; } = null!;
}
