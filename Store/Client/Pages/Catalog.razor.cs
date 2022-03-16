namespace Store.Client.Pages;

[Route(Url)]
[Layout(typeof(BodyContainer))]
public partial class Catalog
{
    public const string Seo = "catalog";
    public const string Url = Seo;

    private List<Breadcrumb> _breadcrumbs = null!;
    private IReadOnlyCollection<Store.Shared.Entities.Product>? _products;

    [Inject]
    public IStringLocalizer<Catalog> Text { get; init; } = null!;

    [Inject]
    public IProductService Service { get; init; } = null!;

    protected override void OnInitialized()
    {
        _breadcrumbs = new()
        {
            new Breadcrumb(Text["HeadingTitle"], Url)
        };

        _products = Service.Get();
    }
}
