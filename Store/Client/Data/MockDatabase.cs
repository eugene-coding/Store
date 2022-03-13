using Entities = Store.Shared.Entities;

namespace Store.Client.Data;

public static class MockDatabase
{
    public static List<Entities.Faq> Questions { get; set; } = new()
    {
        new Entities.Faq()
        {
            Question = "Как часто нужно проходить повышение квалификации?",
            AnswerBody = "<p>Для разных профессий законодательно установлена разная периодичность, но в основном не реже чем раз в 3 года.</p>",
            AnswerFooter = "<button class=\"white\">Задать вопрос</button>",
            ShowInFaqBlock = true,
            Enabled = true
        },
        new Entities.Faq()
        {
            Question = "Как часто нужно проходить повышение квалификации?",
            AnswerBody = "<p>Для разных профессий законодательно установлена разная периодичность, но в основном не реже чем раз в 3 года.</p>",
            AnswerFooter = "<button class=\"white\">Задать вопрос</button>",
            ShowInFaqBlock = true,
            Enabled = true
        },
        new Entities.Faq()
        {
            Question = "Как часто нужно проходить повышение квалификации?",
            AnswerBody = "<p>Для разных профессий законодательно установлена разная периодичность, но в основном не реже чем раз в 3 года.</p>",
            AnswerFooter = "<button class=\"white\">Задать вопрос</button>",
            ShowInFaqBlock = true,
            Enabled = true
        },
        new Entities.Faq()
        {
            Question = "Как часто нужно проходить повышение квалификации?",
            AnswerBody = "<p>Для разных профессий законодательно установлена разная периодичность, но в основном не реже чем раз в 3 года.</p>",
            AnswerFooter = "<button class=\"white\">Задать вопрос</button>",
            ShowInFaqBlock = true,
            Enabled = true
        },
        new Entities.Faq()
        {
            Question = "Как часто нужно проходить повышение квалификации?",
            AnswerBody = "<p>Для разных профессий законодательно установлена разная периодичность, но в основном не реже чем раз в 3 года.</p>",
            AnswerFooter = "<button class=\"white\">Задать вопрос</button>",
            Enabled = true
        }
    };
}
