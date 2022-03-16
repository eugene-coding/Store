namespace Store.Shared.Entities;

public class Product
{
    public int Id { get; init; }
    public string Sku { get; init; } = null!;
    public string Name { get; init; } = null!;
    public string? ShortDescription { get; init; } = null!;
    public string? Description { get; init; }
    public string Image { get; init; } = "images/no-image.svg";

    public decimal Price { get; init; }

    public string Seo { get; init; } = null!;

    public int SortOrder { get; init; }
    public bool Enabled { get; init; }

    // "C" provides unreadable ruble sign
    public string FormatedPrice => $"{Price:N0} ₽";
}
