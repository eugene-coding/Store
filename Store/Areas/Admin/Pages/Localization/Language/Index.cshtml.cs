using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;

using Newtonsoft.Json;

using Store.Areas.Admin.Services;

namespace Store.Areas.Admin.Pages.Localization.Language;

[IgnoreAntiforgeryToken]
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
    public IEnumerable<Breadcrumb> Breadcrumbs { get; private set; } = Array.Empty<Breadcrumb>();

    public void OnGet()
    {
        Breadcrumbs = new Breadcrumb[]
        {
            new Breadcrumb(SharedLocalizer["Heading title"])
        };
    }

    public async Task<IActionResult> OnPostAsync(IReadOnlyCollection<int> selected)
    {
        await _service.DeleteAsync(selected);

        return RedirectToPage();
    }

    public IActionResult OnGetAddForm()
    {
        return Partial("_Form", new LanguageView());
    }

    public async Task<IActionResult> OnGetEditFormAsync(int id)
    {
        var language = await _service.GetAsync(id);

        if (language is null)
        {
            return NotFound();
        }

        return Partial("_Form", language);
    }

    public async Task<IActionResult> OnGetListAsync()
    {
        var languages = await _service.GetAsync();

        return Partial("_List", languages);
    }

    public async Task<IActionResult> OnPostAddLanguageAsync()
    {
        var language = await DeserializeLanguageViewAsync();

        if (language is null || !ModelState.IsValid)
        {
            return new JsonResult(false);
        }

        if (await _service.ExistsAsync(language.Code))
        {
            ModelState.AddModelError(
                $"{nameof(language.Code)}",
                SharedLocalizer["Code already exists"]);

            return new JsonResult(false);
        }

        await _service.AddAsync(language);

        return new JsonResult(true);
    }

    public async Task<JsonResult> OnPostUpdateLanguageAsync()
    {
        var language = await DeserializeLanguageViewAsync();

        if (language is null || !ModelState.IsValid)
        {
            return new JsonResult(false);
        }

        var codeChanged = await _service.GetCodeAsync(language.Id) != language.Code;
        var codeExists = await _service.ExistsAsync(language.Code);

        if (codeChanged && codeExists)
        {
            ModelState.AddModelError(
                $"{nameof(language.Code)}",
                SharedLocalizer["Code already exists"]);

            return new JsonResult(false);
        }

        await _service.UpdateAsync(language);

        return new JsonResult(true);
    }

    private async Task<LanguageView?> DeserializeLanguageViewAsync()
    {
        var requestBody = await new StreamReader(Request.Body).ReadToEndAsync();

        return JsonConvert.DeserializeObject<LanguageView>(requestBody);
    }
}
