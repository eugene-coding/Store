using Microsoft.AspNetCore.Components;

using Store.Shared.Models;

namespace Store.Server.Services;

public sealed class SocialService : ISocialService
{
    public SocialService(NavigationManager manager)
    {
        this.manager = manager;
    }

    public NavigationManager manager { get; set; }


    public async Task<IReadOnlyCollection<Social>> GetAsync()
    {
        IReadOnlyCollection<Social>? socials;

        using (HttpClient _client = new())
        {
            socials = await _client.GetFromJsonAsync<IReadOnlyCollection<Social>>($"{manager.BaseUri}/data/social.json");
        }
            
        return socials ?? new List<Social>();
    }
}
