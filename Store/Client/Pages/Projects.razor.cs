namespace Store.Client.Pages;

[Route(Url)]
public partial class Projects
{
    public const string Seo = "projects";
    public const string Url = Seo;

    [Inject]
    public IStringLocalizer<Projects> Text { get; init; } = null!;
}
