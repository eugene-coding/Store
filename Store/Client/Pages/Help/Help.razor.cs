namespace Store.Client.Pages.Help;

[Route(Url)]
public partial class Help
{
    public const string Seo = "help";
    public const string Url = Seo;

    private List<Breadcrumb>? _breadcrumbs;

    [Inject]
    public IStringLocalizer<Help> Text { get; init; } = null!;

    protected override void OnInitialized()
    {
        _breadcrumbs = new()
        {
            new Breadcrumb(Text["HeadingTitle"], Url)
        };
    }
}
