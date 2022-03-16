using Store.Shared.Entities;

namespace Store.Shared.Services;

public interface IFaqService
{
    Task<IReadOnlyCollection<Faq>> GetAsync();
    Task<IReadOnlyCollection<Faq>> GetForBlockAsync(int count);
}
