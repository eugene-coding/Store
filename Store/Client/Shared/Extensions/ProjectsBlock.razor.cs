using Project = Store.Shared.Entities.Project;

namespace Store.Client.Shared.Extensions;

public partial class ProjectsBlock : IDisposable
{
    private IReadOnlyList<Project>? _projects;

    private PersistingComponentStateSubscription _persistingSubscription;
    private readonly string _persistingKey = "projectsBlock";
    private static bool s_persisted = false;

    [Inject]
    public PersistentComponentState ApplicationState { get; init; } = null!;

    [Inject]
    public IProjectService Service { get; init; } = null!;

    [Inject]
    public IStringLocalizer<ProjectsBlock> Text { get; init; } = null!;

    [Inject]
    public IStringLocalizer<Projects> ProjectsText { get; init; } = null!;

    
    protected override async Task OnInitializedAsync()
    {
        RegisterOnPersisting();

        if (!ApplicationState.TryTakeFromJson<IReadOnlyList<Project>>(
            _persistingKey, out var restored))
        {
            _projects = await Service.GetWithoutImagesAsync(3);
        }
        else
        {
            _projects = restored!;
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
        ApplicationState.PersistAsJson(_persistingKey, _projects);

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _persistingSubscription.Dispose();
    }
}
