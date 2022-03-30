namespace Store.Client.Pages.Company;

[Route(Url)]
public partial class Requisites : IDisposable
{
    public const string Seo = "requisites";
    public const string Url = $"{Company.Url}/{Seo}";
    private const string PersistingKey = "requisites";

    private PersistingComponentStateSubscription _persistingSubscription;
    private IReadOnlyList<Breadcrumb>? _breadcrumbs;
    private IReadOnlyCollection<Requisite>? _requisites;

    [Inject]
    public IStringLocalizer<Requisites> Text { get; init; } = null!;

    [Inject]
    public IStringLocalizer<Company> CompanyText { get; init; } = null!;

    [Inject]
    public PersistentComponentState ApplicationState { get; init; } = null!;

    [Inject]
    public IRequisiteService Service { get; init; } = null!;

    protected override void OnInitialized()
    {
        _breadcrumbs = new List<Breadcrumb>()
        {
            new Breadcrumb(CompanyText["HeadingTitle"], Company.Url),
            new Breadcrumb(Text["HeadingTitle"], Url)
        };
    }

    protected override async Task OnInitializedAsync()
    {
        _persistingSubscription =
                   ApplicationState.RegisterOnPersisting(PersistProjects);

        if (!ApplicationState.TryTakeFromJson<IReadOnlyList<Requisite>>(
            PersistingKey, out var restored))
        {
            _requisites = await Service.GetAsync();
        }
        else
        {
            _requisites = restored!;
        }
    }

    private Task PersistProjects()
    {
        ApplicationState.PersistAsJson(PersistingKey, _requisites);

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _persistingSubscription.Dispose();
    }
}
