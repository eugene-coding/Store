using Microsoft.AspNetCore.Components;

using Store.Services;

namespace Store.Shared;

public partial class Social
{
    private const string SocialIconsPath = "images/icons/socials/";

    private IReadOnlyCollection<Data.Social>? socials;

    [Inject]
    public ISocialService Service { get; init; } = default!;

    protected override async Task OnInitializedAsync()
    {
        socials = await Service.GetNoTrackingAsync();
    }
}
