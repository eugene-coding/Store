namespace Store.Client.Pages;

[Route(Url)]
[Layout(typeof(BodyContainer))]
public partial class Projects : IDisposable
{
    public const string Seo = "projects";
    public const string Url = Seo;

    private List<Breadcrumb> _breadcrumbs = null!;
    private IReadOnlyList<Store.Shared.Entities.Project>? _projects;
    private PersistingComponentStateSubscription persistingSubscription;

    [Inject]
    public IStringLocalizer<Projects> Text { get; init; } = null!;

    [Inject]
    public PersistentComponentState ApplicationState { get; init; } = null!;

    [Inject]
    public IProjectService Service { get; init; } = null!;

    protected override void OnInitialized()
    {
        _breadcrumbs = new()
        {
            new Breadcrumb(Text["HeadingTitle"], Url)
        };
    }

    protected override async Task OnInitializedAsync()
    {
        persistingSubscription =
                    ApplicationState.RegisterOnPersisting(PersistForecasts);

        if (!ApplicationState.TryTakeFromJson<IReadOnlyList<Store.Shared.Entities.Project>>(
            "projectsBlock", out var restored))
        {
            _projects = await Service.GetAsync();
        }
        else
        {
            _projects = restored!;
        }
    }

    private Task PersistForecasts()
    {
        ApplicationState.PersistAsJson("projectsBlock", _projects);

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        persistingSubscription.Dispose();
    }
}
