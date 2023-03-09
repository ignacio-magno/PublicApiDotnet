using Previred.ClientApi;
using Previred.Domain;

namespace Previred;

public class PreviredApi
{
    private readonly LambdaApi _clientApi;

    public PreviredApi(string tokenApi)
    {
        _clientApi = new LambdaApi(new HttpClient(), tokenApi);
    }

    public async Task<Imposition> GetImposition(string pathFile)
    {
        var response = await _clientApi.DoFromFile(pathFile);
        var imposition = new Imposition(response);
        return imposition;
    }
}