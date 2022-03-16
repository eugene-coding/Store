namespace Store.Client.Services;

internal abstract class ServiceBase
{
    private protected HttpClient Client { get; init; }

    private protected ServiceBase(HttpClient client)
    {
        Client = client;
    }
}
