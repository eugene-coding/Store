namespace Store.Client.Pages.Company;

[Route(Url)]
public partial class Policy
{
    public const string Seo = "policy";
    public const string Url = $"{Company.Url}/{Seo}";

    private string _address = null!;
    private IReadOnlyList<Breadcrumb>? _breadcrumbs;

    [Inject]
    public IStringLocalizer<Policy> Text { get; init; } = null!;

    [Inject]
    public IStringLocalizer<Company> CompanyText { get; init; } = null!;

    [Inject]
    public IStringLocalizer<StoreSettings> StoreSettings { get; init; } = null!;

    [Inject]
    public NavigationManager Navigation { get; init; } = null!;

    public MarkupString Content
    {
        get
        {
            var result = Text.GetString("Content", StoreSettings["Name"], _address, Navigation.BaseUri);

            return (MarkupString)result.ToString();
        }
    }

    protected override void OnInitialized()
    {
        _address = $"{StoreSettings["ZipCode"]}, {StoreSettings["Street"]}";

        _breadcrumbs = new List<Breadcrumb>()
        {
            new Breadcrumb(CompanyText["HeadingTitle"], Company.Url),
            new Breadcrumb(Text["HeadingTitle"], Url)
        };
    }
}
