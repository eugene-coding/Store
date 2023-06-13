using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Store.Pages;

/// <summary>
/// Index page model.
/// </summary>
public class IndexModel : PageModel
{
    /// <summary>
    /// <c>GET</c> request handler.
    /// </summary>
    public void OnGet()
    {
        ViewData["Title"] = "Home page";
    }
}
