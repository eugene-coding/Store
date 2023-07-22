using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;

using Store.Areas.Admin.Services;

namespace Store.Areas.Admin.Pages.Localization.Language;

public class IndexModel : PageModel
{
    private readonly ILanguageService _service;

    public IndexModel(IStringLocalizer<IndexModel> localizer,
        IStringLocalizer<LanguageResource> sharedLocalizer,
        IStringLocalizer<CommonResource> commonLocalizer,
        ILanguageService service)
    {
        Localizer = localizer;
        SharedLocalizer = sharedLocalizer;
        CommonLocalizer = commonLocalizer;
        _service = service;
    }

    public IStringLocalizer<IndexModel> Localizer { get; }
    public IStringLocalizer<LanguageResource> SharedLocalizer { get; }
    public IStringLocalizer<CommonResource> CommonLocalizer { get; }
    public IEnumerable<Breadcrumb> Breadcrumbs { get; private set; } = Enumerable.Empty<Breadcrumb>();
    public IReadOnlyCollection<LanguageView> Languages { get; private set; } = Array.Empty<LanguageView>();

    [BindProperty]
    public LanguageView Language { get; set; } = new();

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

    public async Task<IActionResult> OnPostCreateAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        if (await _service.ExistsAsync(Language.Code))
        {
            ModelState.AddModelError(
                $"{nameof(Language)}.{nameof(Language.Code)}",
                SharedLocalizer["Language already exists"]);

            return Page();
        }

        await _service.AddAsync(Language);

        return RedirectToPage();
    }

    public async Task<JsonResult> OnGetGetLanguageAsync(int id)
    {
        var language = await _service.GetAsync(id);

        return new JsonResult(language);
    }

    public async Task<JsonResult> OnPostUpdateLanguageAsync()
    {
        if (!ModelState.IsValid)
        {
            return new JsonResult(false);
        }

        var codeChanged = await _service.GetCodeAsync(Language.Id) != Language.Code;
        var codeExists = await _service.ExistsAsync(Language.Code);

        if (codeChanged && codeExists)
        {
            ModelState.AddModelError(
                $"{nameof(Language)}.{nameof(Language.Code)}",
                SharedLocalizer["Code already exists"]);

            return new JsonResult(false);
        }

        await _service.UpdateAsync(Language);

        return new JsonResult(true);
    }
}
