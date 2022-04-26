using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Store.Pages;

[Route(RelativeUrl)]
public partial class Contacts
{
    public const string RelativeUrl = "contacts";

    [Inject]
    public IStringLocalizer<Contacts> Text { get; init; } = default!;
}
