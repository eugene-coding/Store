namespace Store.Client.Services;

internal abstract class ServiceBase
{

    protected ServiceBase(HttpClient httpClient)
    {
        Client = httpClient;
    }

    protected HttpClient Client { get; init; }
    protected abstract string Route { get; }
}
