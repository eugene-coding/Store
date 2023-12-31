﻿using Microsoft.JSInterop;

namespace Store.Client.Shared.Common.Header;

public partial class MobileHeader : IAsyncDisposable
{
    private IJSObjectReference? _module;

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

    private async void Open()
    {
        if (_module is not null)
        {
            await _module.InvokeVoidAsync("open");
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
