namespace Store.Client.Shared.Extensions;

public partial class Teaser
{
    [Inject]
    public IStringLocalizer<Teaser> Text { get; init; } = null!;
}
