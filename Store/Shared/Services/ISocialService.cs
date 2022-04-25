using Store.Shared.Models;

namespace Store.Shared.Services;

public interface ISocialService
{
    Task<IEnumerable<Social>> GetNoTrackingAsync();
}
