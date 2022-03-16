using Project = Store.Shared.Entities.Project;

namespace Store.Client.Shared.Extensions;

public partial class ProjectsBlock : IDisposable
{
    private IReadOnlyList<Project>? _projects;
    private PersistingComponentStateSubscription persistingSubscription;

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
        persistingSubscription =
                    ApplicationState.RegisterOnPersisting(PersistForecasts);

        if (!ApplicationState.TryTakeFromJson<IReadOnlyList<Project>>(
            "projectsBlock", out var restored))
        {
            _projects = await Service.GetWithoutImagesAsync(3);
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
