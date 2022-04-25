using Microsoft.Extensions.Localization;

namespace Store.Client.Shared;

public partial class Loading
{
    [Inject]
    public IStringLocalizer<Loading> Text { get; init; } = default!;
}
