namespace Store.Client.Pages.Help;

[Route(Url)]
public partial class Delivery
{
    public const string Seo = "delivery";
    public const string Url = $"{Help.Url}/{Seo}";

    private List<Breadcrumb>? _breadcrumbs;

    [Inject]
    public IStringLocalizer<Delivery> Text { get; init; } = null!;

    [Inject]
    public IStringLocalizer<Help> HelpText { get; init; } = null!;

    protected override void OnInitialized()
    {
        _breadcrumbs = new()
        {
            new Breadcrumb(HelpText["HeadingTitle"], Help.Url),
            new Breadcrumb(Text["HeadingTitle"], Url)
        };
    }
}
