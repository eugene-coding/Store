using Entity = Store.Shared.Entities;

namespace Store.Client.Pages;

[Route(Projects.Url + "/{Seo}")]
public partial class Project
{
    private Entity.Project? _project;

    [Parameter, EditorRequired]
    public string Seo { get; init; } = null!;

    private List<Breadcrumb> _breadcrumbs = null!;

    [Inject]
    public IProjectService Service { get; init; } = null!;

    [Inject]
    public IStringLocalizer<Projects> ProjectsText { get; init; } = null!;

    [Inject]
    public NavigationManager Navigation { get; init; } = null!;

    protected override async Task OnInitializedAsync()
    {
        _project = await Service.GetAsync(Seo);

        if (_project is not null)
        {
            _breadcrumbs = new()
            {
                new Breadcrumb(ProjectsText["HeadingTitle"], Projects.Url),
                new Breadcrumb(_project.Name, $"{Projects.Url}/{_project.Seo}")
            };
        }
    }
}
