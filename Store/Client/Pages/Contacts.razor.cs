namespace Store.Client.Pages;

[Route(Url)]
[Layout(typeof(BodyContainer))]
public partial class Contacts
{
    public const string Seo = "contacts";
    public const string Url = Seo;

    private IReadOnlyList<Breadcrumb>? _breadcrumbs;

    [Inject]
    public IStringLocalizer<Contacts> Text { get; init; } = null!;

    [Inject]
    public IStringLocalizer<StoreSettings> StoreSettings { get; init; } = null!;

    public string Alt => Text.GetString("Alt", StoreSettings["Name"]);

    protected override void OnInitialized()
    {
        _breadcrumbs = new List<Breadcrumb>()
        {
            new Breadcrumb(Text["HeadingTitle"], Url)
        };
    }
}
