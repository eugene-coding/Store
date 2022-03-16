namespace Store.Client.Shared.Product;

public partial class ProductThumb
{
    [Parameter, EditorRequired]
    public Store.Shared.Entities.Product Product { get; init; } = null!;
}
