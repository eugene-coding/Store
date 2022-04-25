using Store.Shared.Models;

namespace Store.Client.Shared;

public partial class Badges
{
    private const string BadgeImagesPath = "images/badges/";

    private IEnumerable<Badge>? badges;

    [Inject]
    public IBadgeService Service { get; init; } = default!;

    protected override async Task OnInitializedAsync()
    {
        badges = await Service.GetNoTrackingAsync();
    }
}
