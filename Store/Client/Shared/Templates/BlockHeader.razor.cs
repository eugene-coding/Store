namespace Store.Client.Shared.Templates;

public partial class BlockHeader
{
    [Parameter, EditorRequired]
    public RenderFragment Title { get; init; } = null!;

    [Parameter]
    public RenderFragment? Subtitle { get; init; }

    [Parameter]
    public RenderFragment? Description { get; init; }
}
