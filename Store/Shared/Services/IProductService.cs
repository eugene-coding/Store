using Store.Shared.Entities;

namespace Store.Shared.Services;

public interface IProductService
{
    IReadOnlyCollection<Product> Get();
    Product? Get(string seo);
}
