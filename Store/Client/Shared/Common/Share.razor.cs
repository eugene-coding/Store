namespace Store.Client.Shared.Common;

public partial class Share
{
    [Inject]
    public NavigationManager Navigation { get; init; } = null!;

    [Parameter]
    public string? Title { get; init; }
}
