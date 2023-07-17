using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Store.Areas.Admin.Services;

namespace Store.Areas.Admin.Pages.Localization.Language;

public class IndexModel : PageModel
{
    public IndexModel(IStringLocalizer<LanguageResource> sharedLocalizer)
    {
        SharedLocalizer = sharedLocalizer;
    }

    public IStringLocalizer<LanguageResource> SharedLocalizer { get; }
    public IEnumerable<Breadcrumb> Breadcrumbs { get; private set; } = Enumerable.Empty<Breadcrumb>();
    public IEnumerable<LanguageView> Languages { get; private set; } = Enumerable.Empty<LanguageView>();

    public async Task OnGetAsync([FromServices] ILanguageService service)
    {
        Breadcrumbs = new Breadcrumb[]
        {
            new Breadcrumb(SharedLocalizer["Heading title"])
        };

        Languages = await service.GetAsync();
    }
}
