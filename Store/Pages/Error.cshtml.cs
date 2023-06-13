using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Diagnostics;

namespace Store.Pages;

/// <summary>
/// Error page model.
/// </summary>
[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
[IgnoreAntiforgeryToken]
public class ErrorModel : PageModel
{
    /// <summary>
    /// Request ID.
    /// </summary>
    public string? RequestId { get; private set; }

    /// <summary>
    /// Determines whether to show the <see cref="RequestId"/>.
    /// </summary>
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

    /// <summary>
    /// <c>GET</c> request handler.
    /// </summary>
    public void OnGet()
    {
        ViewData["Title"] = "Error";

        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
    }
}

