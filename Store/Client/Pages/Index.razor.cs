using Microsoft.Extensions.Localization;

namespace Store.Client.Pages;

[Route(RelativeUrl)]
public partial class Index
{
    public const string RelativeUrl = "";

    [Inject]
    public IStringLocalizer<Index> Text { get; init; } = default!;
}
