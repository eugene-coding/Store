using Microsoft.JSInterop;

using Entity = Store.Shared.Entities.Faq;

namespace Store.Client.Pages.Help;

[Route(Url)]
public partial class Faq : IAsyncDisposable
{
    public const string Seo = "faq";
    public const string Url = $"{Help.Url}/{Seo}";

    private List<Breadcrumb>? _breadcrumbs;
    private IReadOnlyCollection<Entity>? _questions;
    private IJSObjectReference? _module;

    [Inject]
    public IFaqService Service { get; init; } = null!;

    [Inject]
    public IStringLocalizer<Faq> Text { get; init; } = null!;

    [Inject]
    public IStringLocalizer<Help> HelpText { get; init; } = null!;

    [Inject]
    public IJSRuntime JS { get; init; } = null!;

    protected override void OnInitialized()
    {
        _breadcrumbs = new()
        {
            new Breadcrumb(HelpText["HeadingTitle"], Help.Url),
            new Breadcrumb(Text["HeadingTitle"], Url)
        };

        _questions = Service.Get();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _module = await JS.InvokeAsync<IJSObjectReference>("import", "./Pages/Help/Faq.razor.js");
        }

        SetSchemaAttributes();
    }

    private async void SetSchemaAttributes()
    {
        if (_module is not null)
        {
            await _module.InvokeVoidAsync("setSchemaAttributes");
        }
    }

    private async void RemoveSchemaAttributes()
    {
        if (_module is not null)
        {
            await _module.InvokeVoidAsync("removeSchemaAttributes");
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (_module is not null)
        {
            RemoveSchemaAttributes();

            await _module.DisposeAsync();
        }
    }
}
