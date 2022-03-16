namespace Store.Shared.Entities;

public class ProductAttribute
{
    public int Id { get; init; }
    public int ProductId { get; init; }
    public int AttributeId { get; init; }
    public string Value { get; init; } = null!;

    public Product? Product { get; init; }
    public Attribute? Attribute { get; init; }
}
