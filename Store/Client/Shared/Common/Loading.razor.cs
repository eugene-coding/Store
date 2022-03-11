namespace Store.Client.Shared.Common;

public partial class Loading
{
    [Inject]
    public IStringLocalizer<Loading> Text { get; init; } = null!;
}
