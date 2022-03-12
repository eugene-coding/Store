namespace Store.Client.Shared.Common;

public partial class Payment
{
    private const string ImagesPath = "images/payment";

    [Inject]
    public IStringLocalizer<Payment> Text { get; init; } = null!;
}
