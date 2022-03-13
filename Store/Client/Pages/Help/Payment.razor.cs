namespace Store.Client.Pages.Help;

[Route(Url)]
public partial class Payment
{
    public const string Seo = "payment";
    public const string Url = $"{Help.Url}/{Seo}";

    private List<Breadcrumb>? _breadcrumbs;

    [Inject]
    public IStringLocalizer<Payment> Text { get; init; } = null!;

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
