using Store.Shared.Models;

namespace Store.Shared.Services;

public interface IBadgeService
{
    Task<IEnumerable<Badge>> GetNoTrackingAsync();
}
