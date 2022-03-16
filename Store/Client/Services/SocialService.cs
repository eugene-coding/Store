using Store.Shared.Models;

using System.Net.Http.Json;

namespace Store.Client.Services;

public sealed class SocialService : ISocialService
{
    private readonly HttpClient _client; 

    public SocialService(HttpClient client)
    {
        _client = client;
    }

    public async Task<IReadOnlyCollection<Social>> GetAsync()
    {
        var socials = await _client.GetFromJsonAsync<IReadOnlyCollection<Social>>("data/social.json");

        return socials ?? new List<Social>();
    }
}
