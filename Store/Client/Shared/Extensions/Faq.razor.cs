using Store.Client.Resources;

using Entity = Store.Shared.Entities.Faq;

namespace Store.Client.Shared.Extensions;

public partial class Faq
{
    private IReadOnlyCollection<Entity>? _questions;

    [Inject]
    public IStringLocalizer<Faq> Text { get; init; } = null!;

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

    protected override void OnInitialized()
    {
        _questions = new List<Entity>()
        {
            new Entity()
            {
                Question = "Как часто нужно проходить повышение квалификации?",
                AnswerBody = "<p>Для разных профессий законодательно установлена разная периодичность, но в основном не реже чем раз в 3 года.</p>",
                AnswerFooter = "<button class=\"white\">Задать вопрос</button>"
            },
            new Entity()
            {
                Question = "Как часто нужно проходить повышение квалификации?",
                AnswerBody = "<p>Для разных профессий законодательно установлена разная периодичность, но в основном не реже чем раз в 3 года.</p>",
                AnswerFooter = "<button class=\"white\">Задать вопрос</button>"
            },
            new Entity()
            {
                Question = "Как часто нужно проходить повышение квалификации?",
                AnswerBody = "<p>Для разных профессий законодательно установлена разная периодичность, но в основном не реже чем раз в 3 года.</p>",
                AnswerFooter = "<button class=\"white\">Задать вопрос</button>"
            }
        };
    }
}
