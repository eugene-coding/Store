namespace Store.Client.Shared.Extensions;

public sealed partial class Teaser
{
    [Inject]
    public IStringLocalizer<Teaser> Text { get; init; } = null!;
}
