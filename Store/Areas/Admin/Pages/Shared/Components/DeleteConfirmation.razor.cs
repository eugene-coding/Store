using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Store.Areas.Admin.Pages.Shared.Components;

public partial class DeleteConfirmation
{
    [Inject]
    private IStringLocalizer<CommonResource> Localizer { get; init; }
}
