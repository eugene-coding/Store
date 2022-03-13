namespace Store.Client.Shared.Common;

public partial class Footer
{
    //private Location? _location;

    //[Inject]
    //public ILocationService Service { get; init; } = null!;

    [Inject]
    public IStringLocalizer<Footer> Text { get; init; } = null!;

    [Inject]
    public IStringLocalizer<Catalog> CatalogText { get; init; } = null!;

    [Inject]
    public IStringLocalizer<Company> CompanyText { get; init; } = null!;

    [Inject]
    public IStringLocalizer<Contacts> ContactsText { get; init; } = null!;

    [Inject]
    public IStringLocalizer<Policy> PolicyText { get; init; } = null!;

    [Inject]
    public IStringLocalizer<StoreSettings> StoreSettings { get; init; } = null!;

    private string Copyright => $"{DateTime.Now.Year} © {Text["AllRightsReserved"]}";

    //protected override async Task OnInitializedAsync()
    //{
    //    _location = await Service.GetFirstAsync();
    //}
}
