using Store.Shared.Entities;

namespace Store.Shared.Services;

public interface IRequisiteService
{
    Task<IReadOnlyCollection<Requisite>> GetAsync();
}
