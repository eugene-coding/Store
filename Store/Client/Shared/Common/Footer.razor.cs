namespace Store.Client.Shared.Common;

public partial class Footer
{
    [Inject]
    public IStringLocalizer<Footer> Text { get; init; } = null!;

    [Inject]
    public IStringLocalizer<Projects> ProjectsText { get; init; } = null!;

    [Inject]
    public IStringLocalizer<Catalog> CatalogText { get; init; } = null!;

    [Inject]
    public IStringLocalizer<Company> CompanyText { get; init; } = null!;

    [Inject]
    public IStringLocalizer<Help> HelpText { get; init; } = null!;

    [Inject]
    public IStringLocalizer<Contacts> ContactsText { get; init; } = null!;

    [Inject]
    public IStringLocalizer<Policy> PolicyText { get; init; } = null!;

    private string Copyright => $"{DateTime.Now.Year} © {Text["AllRightsReserved"]}";
}
