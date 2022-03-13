namespace Store.Client.Shared.Common;

public partial class PaymentMethods
{
    private const string ImagesPath = "images/payment";

    [Inject]
    public IStringLocalizer<PaymentMethods> Text { get; init; } = null!;
}
