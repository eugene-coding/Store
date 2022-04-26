using Store.Data;

namespace Store.Services;

public interface ISocialService
{
    Task<IReadOnlyCollection<Social>> GetNoTrackingAsync();
}
