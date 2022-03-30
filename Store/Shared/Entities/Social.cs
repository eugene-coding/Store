namespace Store.Shared.Entities;

public class Social
{
    public int Id { get; set; }
    public string Key { get; set; }
    public Uri Value { get; set; }
    public string? SvgIconCode { get; set; }
    public int SortOrder { get; set; }
    public bool Enabled { get; set; }

    public Social(string key, Uri value)
    {
        Key = key;
        Value = value;
    }
}
