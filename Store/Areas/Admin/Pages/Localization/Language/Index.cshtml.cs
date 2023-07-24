using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;

using Newtonsoft.Json;

using Store.Areas.Admin.Services;

namespace Store.Areas.Admin.Pages.Localization.Language;

[IgnoreAntiforgeryToken]
public class IndexModel : PageModel
{
    public const string ModalId = "modal";
    public const string ModalContentId = "modal-content";

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

    public async Task<IActionResult> OnGetGetLanguageAsync(int id)
    {
        Language = await _service.GetAsync(id) ?? new();

        return Partial("_Form", Language);
    }

    public async Task<JsonResult> OnPostUpdateLanguageAsync()
    {
        string requestBody = await new StreamReader(Request.Body).ReadToEndAsync();
        var language = JsonConvert.DeserializeObject<LanguageView>(requestBody);

        if (!ModelState.IsValid)
        {
            return new JsonResult(false);
        }

        var codeChanged = await _service.GetCodeAsync(language.Id) != language.Code;
        var codeExists = await _service.ExistsAsync(language.Code);

        if (codeChanged && codeExists)
        {
            ModelState.AddModelError(
                $"{nameof(Language)}.{nameof(Language.Code)}",
                SharedLocalizer["Code already exists"]);

            return new JsonResult(false);
        }

        await _service.UpdateAsync(language);

        return new JsonResult(true);
    }
}
