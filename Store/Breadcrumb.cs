namespace Store;

/// <summary>
/// Represents one of the breadcrumb elements.
/// </summary>
/// <param name="Name">Page name.</param>
/// <param name="Url">Page URL.</param>
public record Breadcrumb(string Name, string? Url = null);
