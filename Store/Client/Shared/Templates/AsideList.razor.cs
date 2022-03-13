namespace Store.Client.Shared.Templates;

public partial class AsideList
{
    [Parameter]
    public IEnumerable<Breadcrumb>? Items { get; init; }

    [Inject]
    public NavigationManager Navigation { get; init; } = null!;
}
