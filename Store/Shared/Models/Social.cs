namespace Store.Shared.Models;

public class Social
{
    public string Key { get; set; }
    public Uri Value { get; set; }

    public Social(string key, Uri value)
    {
        Key = key;
        Value = value;
    }
}
