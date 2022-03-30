
using System.Net.Http.Json;

namespace Store.Client.Services;

internal sealed class SocialService : ServiceBase, ISocialService
{
    private const string Route = "api/social";

    public SocialService(HttpClient client) : base(client)
    {
    }

    public async Task<IReadOnlyCollection<Social>> GetAsync()
    {
        return await Client.GetFromJsonAsync<IReadOnlyCollection<Social>>(Route) ?? new List<Social>();
    }
}
