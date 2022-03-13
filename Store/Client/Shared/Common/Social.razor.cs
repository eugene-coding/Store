using Entity = Store.Shared.Entities;

namespace Store.Client.Shared.Common;

public partial class Social
{
    private IReadOnlyCollection<Entity.Social>? _socials;

    [Inject]
    public ISocialService Service { get; init; } = null!;

    protected override void OnInitialized()
    {
        _socials = Service.Get();
    }
}
