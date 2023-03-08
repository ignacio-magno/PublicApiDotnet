using CotizacionesPrevired.ClientApi;
using Newtonsoft.Json;
using Previred.Domain.ApiResponse;

namespace Previred.ClientApi;

internal class LambdaApi : ClientBase, IClientApi
{
    private readonly string _urlEndpoint = "https://api.ignaciolp.cl/contabilidad/previred/reader-planilla";

    public LambdaApi(HttpClient client, string tokenApi) : base(client)
    {
        if (string.IsNullOrEmpty(tokenApi))
        {
            throw new ArgumentException("Token Api is required");
        }
        
        _client.DefaultRequestHeaders.Add("x-api-key", tokenApi);
    }

    public async Task<ImpositionFromApi> DoFromFile(string pathFile)
    {
        var fileStream = new StreamContent(new FileStream(pathFile, FileMode.Open, FileAccess.Read));
        return await DoFromFile(fileStream);
    }

    public async Task<ImpositionFromApi> DoFromFile(StreamContent file)
    {
        // make formdata with file
        var body = new MultipartFormDataContent
        {
            { file, "planilla", "planilla.pdf" }
        };

        using var response = await _client.PostAsync(_urlEndpoint, body);

        var responseString = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseString);
        }

        return JsonConvert.DeserializeObject<ImpositionFromApi>(responseString) ??
               throw new InvalidOperationException();
    }
}