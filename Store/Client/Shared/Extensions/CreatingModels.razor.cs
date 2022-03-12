namespace Store.Client.Shared.Extensions;

public partial class CreatingModels
{
    private const string ImagesPath = "images/models";

    [Inject]
    public IStringLocalizer<CreatingModels> Text { get; init; } = null!;
}
