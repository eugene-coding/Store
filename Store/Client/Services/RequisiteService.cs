using System.Net.Http.Json;

namespace Store.Client.Services;

internal sealed class RequisiteService : ServiceBase, IRequisiteService
{
    private const string Route = "api/requisite";

    public RequisiteService(HttpClient client) : base(client)
    {
    }

    public async Task<IReadOnlyCollection<Requisite>> GetAsync()
    {
        return await Client.GetFromJsonAsync<IReadOnlyCollection<Requisite>>(Route) ?? new List<Requisite>();
    }
}
