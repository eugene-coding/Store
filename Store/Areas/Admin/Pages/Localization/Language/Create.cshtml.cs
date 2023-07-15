using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;

using Store.Areas.Admin.Services;

namespace Store.Areas.Admin.Pages.Localization.Language;

/// <summary>
/// Create language page model.
/// </summary>
public class CreateModel : PageModel
{
    private Breadcrumb[] _breadcrumbs = Array.Empty<Breadcrumb>();

    /// <summary>
    /// Creates the <see cref="CreateModel"/> instance.
    /// </summary>
    /// <param name="localizer">Page localizer.</param>
    /// <param name="sharedLocalizer">Shared resource localizer.</param>
    public CreateModel(IStringLocalizer<CreateModel> localizer, IStringLocalizer<LanguageResource> sharedLocalizer)
    {
        Localizer = localizer;
        SharedLocalizer = sharedLocalizer;
    }

    /// <summary>
    /// Link to the previous page.
    /// </summary>
    public string PreviousPage => ".";

    /// <summary>
    /// Breadcrumbs.
    /// </summary>
    public IEnumerable<Breadcrumb> Breadcrumbs => _breadcrumbs;

    /// <summary>
    /// Page localizer.
    /// </summary>
    public IStringLocalizer<CreateModel> Localizer { get; }

    /// <summary>
    /// Shared resource localizer.
    /// </summary>
    public IStringLocalizer<LanguageResource> SharedLocalizer { get; }

    /// <inheritdoc cref="LanguageView"/>
    [BindProperty]
    public LanguageView Language { get; set; } = new();

    /// <summary>
    /// <c>GET</c> request handler.
    /// </summary>
    public void OnGet()
    {
        _breadcrumbs = new Breadcrumb[]
        {
            new Breadcrumb(SharedLocalizer["Heading title"], PreviousPage),
            new Breadcrumb(Localizer["Add"])
        };
    }

    /// <summary>
    /// <c>POST</c> request handler.
    /// </summary>
    /// <param name="service">The <see cref="ILanguageService"/>.</param>
    public async Task<IActionResult> OnPostAsync([FromServices] ILanguageService service)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        if (await service.ExistsAsync(Language.Code))
        {
            ModelState.AddModelError(
                $"{nameof(Language)}.{nameof(Language.Code)}",
                Localizer["Language already exists"]);

            return Page();
        }

        await service.AddAsync(Language);

        return Redirect(PreviousPage);
    }
}
