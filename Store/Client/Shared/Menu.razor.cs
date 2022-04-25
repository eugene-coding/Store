using Microsoft.AspNetCore.Components.Routing;
using Microsoft.Extensions.Localization;

using Store.Client.Pages;

namespace Store.Client.Shared;

public partial class Menu : IDisposable
{
    private Link[]? items;

    [Inject] public NavigationManager Navigation { get; init; } = default!;

    [Inject] public IStringLocalizer<Pages.Index> IndexText { get; init; } = default!;
    [Inject] public IStringLocalizer<Contacts> ContactsText { get; init; } = default!;


    protected override void OnInitialized()
    {
        items = new Link[]
        {
            new Link(IndexText["HeadingTitle"], Pages.Index.RelativeUrl),
            new Link(ContactsText["HeadingTitle"], Contacts.RelativeUrl),
        };

        Navigation.LocationChanged += HandleLocationChanged;
    }
    
    private bool IsRelativeUrlActive(string relativeUri)
    {
        return Navigation.ToBaseRelativePath(Navigation.Uri) == relativeUri;
    }

    private void HandleLocationChanged(object? sender, LocationChangedEventArgs e)
    {
        StateHasChanged();
    }

    public void Dispose()
    {
        Navigation.LocationChanged -= HandleLocationChanged;
    }

    record Link(string Name, string Url);
}
