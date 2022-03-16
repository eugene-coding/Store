using System.Net.Http.Json;

using Project = Store.Shared.Entities.Project;

namespace Store.Client.Services;

internal sealed class ProjectService : ServiceBase, IProjectService
{
    private const string Route = "api/project";

    public ProjectService(HttpClient client) : base(client)
    {
    }

    public async Task<IReadOnlyList<Project>> GetAsync()
    {
        return await Client.GetFromJsonAsync<IReadOnlyList<Project>>(Route) ?? new List<Project>();
    }

    public async Task<Project?> GetAsync(int id)
    {
        return await Client.GetFromJsonAsync<Project>($"{Route}/id/{id}");
    }
    
    public async Task<Project?> GetAsync(string seo)
    {
        return await Client.GetFromJsonAsync<Project>($"{Route}/seo/{seo}");
    }

    public async Task<int> GetCountAsync()
    {
        return await Client.GetFromJsonAsync<int>($"{Route}/count");
    }

    public async Task<IReadOnlyList<Project>> GetWithoutImagesAsync(int count, int skip = 0)
    {
        IReadOnlyList<Project>? projects;

        var api = $"{Route}/count/{count}";

        if (skip == 0)
        {
            api += $"/skip/{skip}";
        }

        projects = await Client.GetFromJsonAsync<IReadOnlyList<Project>>(api);

        return projects ?? new List<Project>();
    }
}
