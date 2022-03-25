namespace Store.Client.Shared.Common;

public sealed partial class Loading
{
    [Inject]
    public IStringLocalizer<Loading> Text { get; init; } = null!;
}
