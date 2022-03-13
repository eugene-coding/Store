using Entity = Store.Shared.Entities.Faq;

namespace Store.Client.Shared.Templates;

public partial class FaqList
{
    [Parameter]
    public IReadOnlyCollection<Entity> Items { get; init; } = null!;
}
