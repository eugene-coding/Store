namespace Store.Client.Pages.Company;

[Route(Url)]
public partial class Requisites
{
    public const string Seo = "requisites";
    public const string Url = $"{Company.Url}/{Seo}";

    private IReadOnlyList<Breadcrumb>? _breadcrumbs;

    [Inject]
    public IStringLocalizer<Requisites> Text { get; init; } = null!;

    [Inject]
    public IStringLocalizer<Company> CompanyText { get; init; } = null!;

    [Inject]
    public IStringLocalizer<StoreSettings> StoreSettings { get; init; } = null!;

    [Inject]
    public IStringLocalizer<RequisitesSettings> RequisitesSettings { get; init; } = null!;

    [Inject]
    public NavigationManager Navigation { get; init; } = null!;

    protected override void OnInitialized()
    {
        _breadcrumbs = new List<Breadcrumb>()
        {
            new Breadcrumb(CompanyText["HeadingTitle"], Company.Url),
            new Breadcrumb(Text["HeadingTitle"], Url)
        };
    }
}
