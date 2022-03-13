namespace Store.Client.Shared.Common;

public partial class Address
{
    [Inject]
    public IStringLocalizer<StoreSettings> StoreSettings { get; init; } = null!;

    [Parameter]
    public bool WhiteText { get; init; }
}
