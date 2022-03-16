using Store.Client.Data;

using Product = Store.Shared.Entities.Product;

namespace Store.Client.Services;

internal sealed class ProductService : ServiceBase, IProductService
{
    public ProductService(HttpClient client) : base(client)
    {
    }

    public IReadOnlyCollection<Product> Get()
    {
        return MockDatabase.Products;
    }

    public Product? Get(string seo)
    {
        return MockDatabase.Products
            .Where(product => product.Seo == seo)
            .FirstOrDefault();
    }
}
