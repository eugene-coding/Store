using Store.Data;

namespace Store.Services;

public interface IBadgeService
{
    Task<IReadOnlyCollection<Badge>> GetNoTrackingAsync();
}
