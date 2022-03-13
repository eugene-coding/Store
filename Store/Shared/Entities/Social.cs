namespace Store.Shared.Entities;

public class Social
{
    public int Id { get; set; }
    public string Key { get; set; } = null!;
    public Uri Value { get; set; } = null!;
}
