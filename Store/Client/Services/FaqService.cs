using System.Net.Http.Json;

using Faq = Store.Shared.Entities.Faq;

namespace Store.Client.Services;

internal sealed class FaqService : ServiceBase, IFaqService
{
    public FaqService(HttpClient client) : base(client)
    {
    }

    public async Task<IReadOnlyCollection<Faq>> GetAsync()
    {
        return await Client.GetFromJsonAsync<IReadOnlyCollection<Faq>>("api/faq") ?? new List<Faq>();
    }

    public async Task<IReadOnlyCollection<Faq>> GetForBlockAsync(int count)
    {
        return await Client.GetFromJsonAsync<IReadOnlyCollection<Faq>>($"api/faq/block/{count}") ?? new List<Faq>();
    }
}
