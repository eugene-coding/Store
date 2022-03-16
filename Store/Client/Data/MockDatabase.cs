using Entities = Store.Shared.Entities;
using Product = Store.Shared.Entities.Product;

namespace Store.Client.Data;

public static class MockDatabase
{
    public static List<Entities.Product> Products { get; set; } = new()
    {
        new Product()
        {
            Name = "Вазон",
            Description = "Длинное описание",
            ShortDescription = "Короткое описание",
            Sku = "207291",
            Image = "https://allcorp3-demo.ru/upload/iblock/406/4068df42140e88e7fb62394620b16399.jpg",
            Seo ="1"
            
        },
        new Product()
        {
            Name = "Новогодняя снежинка (большая)",
            Description = "Длинное описание",
            ShortDescription = "Короткое описание",
            Sku = "Артикул",
            Price = 12999m,
            Image = "https://allcorp3-demo.ru/upload/iblock/406/4068df42140e88e7fb62394620b16399.jpg",
            Seo = "2"
        },
        new Product()
        {
            Name = "Новогодняя снежинка (RGB)",
            Description = "Длинное описание",
            ShortDescription = "Короткое описание",
            Sku = "Артикул",
            Seo = "3"
        },
        new Product()
        {
            Name = "Снеговик на пеньке",
            Description = "Длинное описание",
            ShortDescription = "Короткое описание",
            Sku = "Артикул",
            Seo = "4"
        }
    };
}
