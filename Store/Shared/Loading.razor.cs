using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Store.Shared;

public partial class Loading
{
    [Inject]
    public IStringLocalizer<Loading> Text { get; init; } = default!;
}
