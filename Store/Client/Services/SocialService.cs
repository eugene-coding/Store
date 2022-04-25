using Store.Shared.Models;

using System.Net.Http.Json;

namespace Store.Client.Services;

internal sealed class SocialService : ServiceBase, ISocialService
{
    public SocialService(HttpClient client) : base(client)
    {
    }

    protected override string Route => "api/social";

    public async Task<IEnumerable<Social>> GetNoTrackingAsync()
    {
        var result = await Client.GetFromJsonAsync<IEnumerable<Social>>(Route);

        return result ?? Enumerable.Empty<Social>();
    }
}
