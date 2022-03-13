using Microsoft.JSInterop;

namespace Store.Client.Shared.Common.Header;

public partial class MobileMenu : IAsyncDisposable
{
    private IJSObjectReference? _module;

    [Inject]
    public IStringLocalizer<Help> HelpText { get; init; } = null!;

    [Inject]
    public IStringLocalizer<Company> CompanyText { get; init; } = null!;

    [Inject]
    public IStringLocalizer<Contacts> ContactsText { get; init; } = null!;

    [Inject]
    public IStringLocalizer<StoreSettings> StoreSettings { get; init; } = null!;

    [Inject]
    public IJSRuntime JS { get; init; } = null!;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _module = await JS.InvokeAsync<IJSObjectReference>("import", "./Shared/Common/Header/MobileMenu.razor.js");
        }
    }

    private async void Close()
    {
        if (_module is not null)
        {
            await _module.InvokeVoidAsync("close");
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (_module is not null)
        {
            await _module.DisposeAsync();
        }
    }
}
