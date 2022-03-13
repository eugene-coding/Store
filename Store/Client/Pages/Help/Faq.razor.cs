using Entity = Store.Shared.Entities.Faq;

namespace Store.Client.Pages.Help;

[Route(Url)]
public partial class Faq
{
    public const string Seo = "faq";
    public const string Url = $"{Help.Url}/{Seo}";

    private List<Breadcrumb>? _breadcrumbs;
    private IReadOnlyCollection<Entity>? _questions;

    [Inject]
    public IFaqService Service { get; init; } = null!;

    [Inject]
    public IStringLocalizer<Faq> Text { get; init; } = null!;

    [Inject]
    public IStringLocalizer<Help> HelpText { get; init; } = null!;

    protected override void OnInitialized()
    {
        _breadcrumbs = new()
        {
            new Breadcrumb(HelpText["HeadingTitle"], Help.Url),
            new Breadcrumb(Text["HeadingTitle"], Url)
        };

        _questions = Service.Get();
    }
}
