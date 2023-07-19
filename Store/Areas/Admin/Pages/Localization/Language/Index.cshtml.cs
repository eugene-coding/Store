using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;

using Store.Areas.Admin.Services;

namespace Store.Areas.Admin.Pages.Localization.Language;

public class IndexModel : PageModel
{
    private readonly ILanguageService _service;

    public IndexModel(IStringLocalizer<IndexModel> localizer, IStringLocalizer<LanguageResource> sharedLocalizer, ILanguageService service)
    {
        Localizer = localizer;
        SharedLocalizer = sharedLocalizer;
        _service = service;
    }

    public IStringLocalizer<IndexModel> Localizer { get; }
    public IStringLocalizer<LanguageResource> SharedLocalizer { get; }
    public IEnumerable<Breadcrumb> Breadcrumbs { get; private set; } = Enumerable.Empty<Breadcrumb>();
    public IReadOnlyCollection<LanguageView> Languages { get; private set; } = Array.Empty<LanguageView>();

    public async Task OnGetAsync(string sort)
    {
        Breadcrumbs = new Breadcrumb[]
        {
            new Breadcrumb(SharedLocalizer["Heading title"])
        };

        Languages = await _service.GetAsync(sort);
    }

    public async Task<IActionResult> OnPostAsync(IReadOnlyCollection<int> selected)
    {
        await _service.DeleteAsync(selected);

        return RedirectToPage();
    }
}
