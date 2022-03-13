using Store.Client.Data;

using Faq = Store.Shared.Entities.Faq;

namespace Store.Client.Services;

public class FaqService : IFaqService
{
    public IReadOnlyCollection<Faq> Get()
    {
        return MockDatabase.Questions;
    }

    public IReadOnlyCollection<Faq> GetForBlock(int count)
    {
        return MockDatabase.Questions
            .Where(question => question.ShowInFaqBlock)
            .OrderBy(question => question.SortOrder)
            .Take(count)
            .ToList();
    }
}
