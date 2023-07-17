using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;

using Store.Areas.Admin.Services;

namespace Store.Areas.Admin.Pages.Localization.Language;

/// <summary>
/// Edit language page model.
/// </summary>
public class EditModel : PageModel
{
    private readonly ILanguageService _service;

    /// <summary>
    /// Creates the <see cref="EditModel"/> instance.
    /// </summary>
    /// <param name="localizer">Page localizer.</param>
    /// <param name="sharedLocalizer">Shared resource localizer.</param>
    /// <param name="service">The <see cref="ILanguageService"/>.</param>
    public EditModel(IStringLocalizer<EditModel> localizer, IStringLocalizer<LanguageResource> sharedLocalizer, ILanguageService service)
    {
        Localizer = localizer;
        SharedLocalizer = sharedLocalizer;
        _service = service;
    }

    /// <summary>
    /// Link to the previous page.
    /// </summary>
    public string PreviousPage => ".";

    /// <summary>
    /// Page localizer.
    /// </summary>
    public IStringLocalizer<EditModel> Localizer { get; }

    /// <summary>
    /// Shared resource localizer.
    /// </summary>
    public IStringLocalizer<LanguageResource> SharedLocalizer { get; }

    /// <inheritdoc cref="LanguageView"/>
    [BindProperty]
    public LanguageView Language { get; set; } = null!;

    /// <summary>
    /// Breadcrumbs.
    /// </summary>
    public IEnumerable<Breadcrumb> Breadcrumbs { get; private set; } = Enumerable.Empty<Breadcrumb>();

    /// <summary>
    /// <c>GET</c> request handler.
    /// </summary>
    public void OnGet(int id)
    {
        Breadcrumbs = new Breadcrumb[]
        {
            new Breadcrumb(SharedLocalizer["Heading title"], PreviousPage),
            new Breadcrumb(Localizer["Edit"])
        };
    }

    /// <summary>
    /// <c>POST</c> request handler.
    /// </summary>
    public async Task<IActionResult> OnPostAsync()
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

        return Redirect(PreviousPage);
    }
}
