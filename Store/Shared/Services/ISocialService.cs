using Store.Shared.Entities;

namespace Store.Shared.Services;

public interface ISocialService
{
    Task<IReadOnlyCollection<Social>> GetAsync();
}
