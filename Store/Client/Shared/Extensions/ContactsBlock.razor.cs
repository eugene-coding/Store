namespace Store.Client.Shared.Extensions;

public partial class ContactsBlock
{
    [Inject]
    public IStringLocalizer<Contacts> Text { get; set; } = null!;

    [Inject]
    public IStringLocalizer<StoreSettings> StoreSettings { get; set; } = null!;
}
