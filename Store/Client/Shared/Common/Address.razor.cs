namespace Store.Client.Shared.Common;

public sealed partial class Address
{
    private string _class = "address";
    private string _fullAddress = string.Empty;

    [Inject]
    public IStringLocalizer<StoreSettings> StoreSettings { get; init; } = null!;

    [Parameter]
    public bool LightStyle { get; init; }

    protected override void OnInitialized()
    {
        _fullAddress = GetFullAddress();
    }

    protected override void OnParametersSet()
    {
        if (LightStyle)
        {
            _class += " address_light";
        }
    }

    private string GetFullAddress()
    {
        bool isCityEmpty = string.IsNullOrWhiteSpace(StoreSettings["City"]);
        bool isStreetEmpty = string.IsNullOrWhiteSpace(StoreSettings["Street"]);

        string address = string.Empty;

        if (isCityEmpty)
        {
            if (!isStreetEmpty)
            {
                address = StoreSettings["Street"];
            }
        }
        else
        {
            address = StoreSettings["City"];

            if (!isStreetEmpty)
            {
                address += $", {StoreSettings["Street"]}";
            }
        }

        return address;
    }
}
