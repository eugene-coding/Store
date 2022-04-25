using Store.Shared.Models;

using System.Net.Http.Json;

namespace Store.Client.Services;

internal sealed class BadgeService : ServiceBase, IBadgeService
{
    public BadgeService(HttpClient httpClient) : base(httpClient)
    {
    }

    protected override string Route => "api/badge";

    public async Task<IEnumerable<Badge>> GetNoTrackingAsync()
    {
        var result = await Client.GetFromJsonAsync<IEnumerable<Badge>>(Route);

        return result ?? Enumerable.Empty<Badge>();
    }
}
