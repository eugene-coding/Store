using Microsoft.AspNetCore.Components;

using Store.Shared.Models;

namespace Store.Server.Services;

public sealed class SocialService : ISocialService
{
    private readonly NavigationManager _manager;

    public SocialService(NavigationManager manager)
    {
        _manager = manager;
    }

    public async Task<IReadOnlyCollection<Social>> GetAsync()
    {
        IReadOnlyCollection<Social>? socials;

        using (HttpClient _client = new())
        {
            socials = await _client.GetFromJsonAsync<IReadOnlyCollection<Social>>($"{_manager.BaseUri}/data/social.json");
        }
            
        return socials ?? new List<Social>();
    }
}
