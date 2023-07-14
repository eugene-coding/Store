using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Store.Areas.Admin.Pages.Localization.Length.Create;

public class IndexModel : PageModel
{
    private Breadcrumb[] _breadcrumbs = Array.Empty<Breadcrumb>();

    public Uri BackUrl { get; } = new Uri(".", UriKind.Relative);
    public IEnumerable<Breadcrumb> Breadcrumbs => _breadcrumbs;

    public void OnGet()
    {
        _breadcrumbs = new Breadcrumb[] {
            new Breadcrumb("Previous page", BackUrl.ToString()),
            new Breadcrumb("Heading title"),
        };
    }
}
