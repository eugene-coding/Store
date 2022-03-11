namespace Store.Client.Shared.Common;

public partial class Breadcrumbs
{
    private readonly List<Breadcrumb>? _items;

    [Inject]
    public IStringLocalizer<Breadcrumbs> Text { get; init; } = null!;

    [Parameter, EditorRequired]
    public IReadOnlyList<Breadcrumb>? Items
    {
        get => _items;
        init
        {
            if (value is not null && value.Count > 0)
            {
                Breadcrumb firstBreadcrumb = new(Text["Home"], "/");

                _items = new()
                {
                    firstBreadcrumb
                };

                _items.AddRange(value);
            }
        }
    }
}

public record Breadcrumb
{
    public string Name { get; init; }
    public Uri Url { get; init; }
 
    public Breadcrumb(string name, string url)
    {
        Url = ValidateUrl(url);
        Name = name;
    }

    private static Uri ValidateUrl(string url)
    {
        if (Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out Uri? result))
        {
            return result;
        }

        throw new UriFormatException($"Url isn't valid: {url}");
    }
}
