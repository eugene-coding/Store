using Entity = Store.Shared.Entities;

namespace Store.Client.Shared.Common;

public partial class Social : IDisposable
{

    private static bool s_persisted = false;
    private static IReadOnlyCollection<Entity.Social>? s_socials;
    private readonly string _persistingKey = "social";
    private string _class = "social";
    private PersistingComponentStateSubscription _persistingSubscription;

    [Inject]
    public ISocialService Service { get; init; } = null!;

    [Inject]
    public PersistentComponentState ApplicationState { get; init; } = null!;

    [Parameter]
    public bool LightStyle { get; init; }

    [Parameter]
    public bool DarkStyle { get; init; }

    protected override void OnParametersSet()
    {
        if (LightStyle)
        {
            _class += " social_light";
        }

        if (DarkStyle)
        {
            _class += " social_dark";
        }
    }

    protected override async Task OnInitializedAsync()
    {
        if (s_socials is null)
        {
            RegisterOnPersisting();

            if (!ApplicationState.TryTakeFromJson<IReadOnlyList<Entity.Social>>(
                _persistingKey, out var restored))
            {
                s_socials = await Service.GetAsync();
            }
            else
            {
                s_socials = restored!;
            }
        }
    }

    private void RegisterOnPersisting()
    {
        if (!s_persisted)
        {
            _persistingSubscription = ApplicationState.RegisterOnPersisting(Persist);

            s_persisted = true;
        }
    }

    private Task Persist()
    {
        ApplicationState.PersistAsJson(_persistingKey, s_socials);

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _persistingSubscription.Dispose();
    }
}
