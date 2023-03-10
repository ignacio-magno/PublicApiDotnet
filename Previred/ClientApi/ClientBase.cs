namespace Previred.ClientApi;

public abstract class ClientBase
{
    protected HttpClient _client;

    public ClientBase(HttpClient client) => _client = client;
}