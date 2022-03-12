namespace Store.Client.Shared.Common;

public partial class PageHeader
{
    [Parameter, EditorRequired]
    public IReadOnlyList<Breadcrumb> Breadcrumbs { get; init; } = null!;

    [Parameter]
    public string? Title { get; init; }
}
