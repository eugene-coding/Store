namespace Store.Client.Shared;

public partial class Social
{
    private const string SocialIconsPath = "images/icons/socials/";

    private IEnumerable<Store.Shared.Models.Social>? socials;

    [Inject]
    public ISocialService Service { get; init; } = default!;

    protected override async Task OnInitializedAsync()
    {
        socials = await Service.GetNoTrackingAsync();
    }
}
