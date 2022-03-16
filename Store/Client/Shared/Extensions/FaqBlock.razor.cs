using Entity = Store.Shared.Entities.Faq;

namespace Store.Client.Shared.Extensions;

public partial class FaqBlock
{
    private IReadOnlyCollection<Entity>? _questions;

    [Inject]
    public IFaqService Service { get; init; } = null!;

    [Inject]
    public IStringLocalizer<FaqBlock> Text { get; init; } = null!;

    [Inject]
    public IStringLocalizer<StoreSettings> StoreSettings { get; init; } = null!;

    private MarkupString Description
    {
        get
        {
            var email = StoreSettings["Email"].ToString();
            var phone = StoreSettings["Phone"].ToString();

            var description = Text.GetString("Description", email, phone);

            return (MarkupString)description.ToString();
        }
    }

    protected override async Task OnInitializedAsync()
    {
        _questions = await Service.GetForBlockAsync(3);
    }
}
