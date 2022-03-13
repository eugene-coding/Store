using Faq = Store.Client.Pages.Help.Faq;

namespace Store.Client.Shared.Layouts;

public partial class HelpLayout
{
    private List<Breadcrumb> _asideMenu = null!;

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

    protected override void OnInitialized()
    {
        _asideMenu = new()
        {
            new Breadcrumb(HelpText["HeadingTitle"], Help.Url),
            new Breadcrumb(PaymentText["HeadingTitle"], Payment.Url),
            new Breadcrumb(DeliveryText["HeadingTitle"], Delivery.Url),
            new Breadcrumb(WarrantyText["HeadingTitle"], Warranty.Url),
            new Breadcrumb(FaqText["HeadingTitle"], Faq.Url)
        };
    }
}
