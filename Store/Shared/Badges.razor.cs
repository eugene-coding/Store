using Microsoft.AspNetCore.Components;

using Store.Services;

namespace Store.Shared;

public partial class Badges
{
    private const string BadgeImagesPath = "images/badges/";

    private IReadOnlyCollection<Data.Badge>? badges;

    [Inject]
    public IBadgeService Service { get; init; } = default!;

    protected override async Task OnInitializedAsync()
    {
        badges = await Service.GetNoTrackingAsync();
    }
}
