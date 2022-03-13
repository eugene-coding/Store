using Store.Shared.Entities;

namespace Store.Shared.Services;

public interface IFaqService
{
    IReadOnlyCollection<Faq> Get();
    IReadOnlyCollection<Faq> GetForBlock(int count);
}
