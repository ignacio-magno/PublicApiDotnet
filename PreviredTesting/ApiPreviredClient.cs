using Previred.ClientApi;
using FluentAssertions;
using DotNetEnv;

namespace PreviredTesting;

public class ApiPreviredClient
{
    private string _tokenApi => Credentials.Instance.TokenApi;
    private string pathFileTest = Credentials.Instance.PathFileTest;

    [Test]
    public async Task TestCallEndpoint()
    {
        var client = new LambdaApi(new HttpClient(), _tokenApi);

        var response = await client.DoFromFile(pathFileTest);

        response.Should().NotBeNull();
    }
}