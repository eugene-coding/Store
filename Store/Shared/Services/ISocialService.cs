using Store.Shared.Entities;

namespace Store.Shared.Services;

public interface ISocialService
{
    IReadOnlyCollection<Social> Get();
}
