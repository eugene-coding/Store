namespace Store.Shared.Entities;

public class Attribute
{
    public int Id { get; init; }
    public string Name { get; init; } = null!;
    public int SortOrder { get; init; }
}
