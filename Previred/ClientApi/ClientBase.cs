namespace CotizacionesPrevired.ClientApi;

public abstract class ClientBase
{
    protected HttpClient _client;

    public ClientBase(HttpClient client)
    {
        _client = client;
        if (!_client.DefaultRequestHeaders.Contains("Authorization"))
        {
            _client.DefaultRequestHeaders.Add("Authorization", "1234567890");
        }
    }
}