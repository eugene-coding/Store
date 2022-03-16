using Store.Shared.Entities;

namespace Store.Shared.Services;

public interface IProjectService
{
    Task<IReadOnlyList<Project>> GetAsync();
    Task<Project?> GetAsync(string seo);
    Task<IReadOnlyList<Project>> GetWithoutImagesAsync(int count, int skip = 0);
    Task<int> GetCountAsync();
}
