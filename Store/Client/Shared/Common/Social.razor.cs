using Models = Store.Shared.Models;

namespace Store.Client.Shared.Common;

public partial class Social
{
    private IReadOnlyCollection<Models.Social>? _socials;

    [Inject]
    public ISocialService Service { get; init; } = null!;

    protected override async Task OnInitializedAsync()
    {
        _socials = await Service.GetAsync();
    }
}
