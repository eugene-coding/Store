namespace Store.Client.Pages.Company;

[Route(Url)]
public partial class Company
{
    public const string Seo = "company";
    public const string Url = Seo;

    private IReadOnlyList<Breadcrumb>? _breadcrumbs;

    [Inject]
    public IStringLocalizer<Company> Text { get; init; } = null!;

    [Inject]
    public IStringLocalizer<StoreSettings> StoreSettings { get; init; } = null!;

    private string StoreName => StoreSettings["Name"];
    private string Alt => Text.GetString("Alt", StoreName);
    private MarkupString Content
    {
        get
        {
            var result = Text.GetString("Content", StoreName);

            return (MarkupString)result.ToString();
        }
    }

    protected override void OnInitialized()
    {
        _breadcrumbs = new List<Breadcrumb>()
        {
            new Breadcrumb(Text["HeadingTitle"], Url)
        };
    }
}
