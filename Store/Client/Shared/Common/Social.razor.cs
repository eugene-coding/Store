using Models = Store.Shared.Models;

namespace Store.Client.Shared.Common;

public partial class Social : IDisposable
{
    private static IReadOnlyCollection<Models.Social>? s_socials;

    private PersistingComponentStateSubscription _persistingSubscription;
    private readonly string _persistingKey = "social";
    private static bool s_persisted = false;

    [Inject]
    public ISocialService Service { get; init; } = null!;

    [Inject]
    public PersistentComponentState ApplicationState { get; init; } = null!;

    protected override async Task OnInitializedAsync()
    {
        if (s_socials is null)
        {
            RegisterOnPersisting();

            if (!ApplicationState.TryTakeFromJson<IReadOnlyList<Models.Social>>(
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
