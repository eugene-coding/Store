using Faq = Store.Client.Pages.Help.Faq;

namespace Store.Client.Shared.Common.Header;

public partial class DesktopHeader
{
    [Inject] 
    public IStringLocalizer<StoreSettings> StoreSettings { get; init; } = null!;
    
    [Inject] 
    public IStringLocalizer<Help> HelpText { get; init; } = null!;
    
    [Inject] 
    public IStringLocalizer<Faq> FaqText { get; init; } = null!;
    
    [Inject] 
    public IStringLocalizer<Payment> PaymentText { get; init; } = null!;
    
    [Inject] 
    public IStringLocalizer<Delivery> DeliveryText { get; init; } = null!;
    
    [Inject] 
    public IStringLocalizer<Warranty> WarrantyText { get; init; } = null!;
    
    [Inject] 
    public IStringLocalizer<Projects> ProjectsText { get; init; } = null!;
    
    [Inject] 
    public IStringLocalizer<Company> CompanyText { get; init; } = null!;
    
    [Inject] 
    public IStringLocalizer<Contacts> ContactsText { get; init; } = null!;

    [Parameter]
    public bool Overlayed { get; init; }
}
