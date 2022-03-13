namespace Store.Client.Shared.Layouts;

public partial class CompanyLayout
{
    private List<Breadcrumb> _asideMenu = null!;

    [Inject]
    public IStringLocalizer<Company> CompanyText { get; init; } = null!;

    [Inject]
    public IStringLocalizer<Requisites> RequisitesText { get; init; } = null!;

    [Inject]
    public IStringLocalizer<Policy> PolicyText { get; init; } = null!;

    protected override void OnInitialized()
    {
        _asideMenu = new()
        {
            new Breadcrumb(CompanyText["HeadingTitle"], Company.Url),
            new Breadcrumb(RequisitesText["HeadingTitle"], Requisites.Url),
            new Breadcrumb(PolicyText["HeadingTitle"], Policy.Url),
        };
    }
}
