using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;

using Store.Areas.Admin.Services;

using System.Globalization;

namespace Store.Areas.Admin.Pages.Localization.Language.Create;

/// <summary>
/// Create language page model.
/// </summary>
public class IndexModel : PageModel
{
    /// <summary>
    /// Previous page.
    /// </summary>
    public static Uri BackUrl { get; } = new(".", UriKind.Relative);

    /// <summary>
    /// Creates the <see cref="IndexModel"/> instance.
    /// </summary>
    /// <param name="localizer">Page localizer.</param>
    /// <param name="sharedLocalizer">Shared resource localizer.</param>
    public IndexModel(IStringLocalizer<IndexModel> localizer, IStringLocalizer<LanguageResource> sharedLocalizer)
    {
        Localizer = localizer;
        SharedLocalizer = sharedLocalizer;
    }

    /// <inheritdoc cref="LanguageView"/>
    [BindProperty]
    public LanguageView Language { get; set; } = new();

    /// <summary>
    /// Page localizer.
    /// </summary>
    public IStringLocalizer<IndexModel> Localizer { get; }

    /// <summary>
    /// Shared resource localizer.
    /// </summary>
    public IStringLocalizer<LanguageResource> SharedLocalizer { get; }

    /// <summary>
    /// Breadcrumbs.
    /// </summary>
    public List<Breadcrumb> Breadcrumbs { get; private set; } = new List<Breadcrumb>();

    /// <summary>
    /// <c>GET</c> request handler.
    /// </summary>
    public void OnGet()
    {
        Breadcrumbs.Add(new Breadcrumb(SharedLocalizer["Heading title"], BackUrl.ToString()));
        Breadcrumbs.Add(new Breadcrumb(Localizer["Add"]));
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

        if (!IsCodeValid())
        {
            ModelState.AddModelError(
                $"{nameof(Language)}.{nameof(Language.Code)}",
                Localizer["Unable to determine language"]);

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

        return Redirect(BackUrl.ToString());
    }

    private bool IsCodeValid()
    {
        try
        {
            var culture = new CultureInfo(Language.Code);

            return !culture.CultureTypes.HasFlag(CultureTypes.UserCustomCulture);
        }
        catch (CultureNotFoundException)
        {
            return false;
        }
    }
}
