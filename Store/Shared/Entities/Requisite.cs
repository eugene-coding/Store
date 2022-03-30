using System.ComponentModel.DataAnnotations;

namespace Store.Shared.Entities;

public sealed class Requisite
{
    public int Id { get; set; }
    public string Key { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }
    public int SortOrder { get; set; }
    public bool Enabled { get; set; }

    public Requisite(string key, string name, string value)
    {
        Key = key;
        Name = name;
        Value = value;
    }
}
