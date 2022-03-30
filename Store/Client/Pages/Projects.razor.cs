using Entity = Store.Shared.Entities;

namespace Store.Client.Pages;

[Route(Url)]
[Layout(typeof(BodyContainer))]
public partial class Projects : IDisposable
{
    public const string Seo = "projects";
    public const string Url = Seo;
    private const string PersistingKey = "projectsBlock";

    private PersistingComponentStateSubscription _persistingSubscription;
    private IReadOnlyList<Breadcrumb>? _breadcrumbs;
    private IReadOnlyList<Entity.Project>? _projects;

    [Inject]
    public IStringLocalizer<Projects> Text { get; init; } = null!;

    [Inject]
    public PersistentComponentState ApplicationState { get; init; } = null!;

    [Inject]
    public IProjectService Service { get; init; } = null!;

    protected override void OnInitialized()
    {
        _breadcrumbs = new List<Breadcrumb>()
        {
            new Breadcrumb(Text["HeadingTitle"], Url)
        };
    }

    protected override async Task OnInitializedAsync()
    {
        _persistingSubscription =
                    ApplicationState.RegisterOnPersisting(PersistProjects);

        if (!ApplicationState.TryTakeFromJson<IReadOnlyList<Entity.Project>>(
            PersistingKey, out var restored))
        {
            _projects = await Service.GetAsync();
        }
        else
        {
            _projects = restored!;
        }
    }

    private Task PersistProjects()
    {
        ApplicationState.PersistAsJson(PersistingKey, _projects);

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _persistingSubscription.Dispose();
    }
}
