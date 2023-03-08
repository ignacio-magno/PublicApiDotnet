using Previred.ClientApi;
using FluentAssertions;
using DotNetEnv;

namespace PreviredTesting;

public class ApiPreviredClient
{
    private string pathFileTest = ".files/planillaTest.pdf";
    private string _tokenApi;

    [SetUp]
    public void Setup()
    {
        Env.Load();
       _tokenApi =  Env.GetString("TokenApi");
    }

    [Test]
    public async Task TestCallEndpoint()
    {
        var client = new LambdaApi(new HttpClient(), _tokenApi);

        var response = await client.DoFromFile(pathFileTest);

        response.Should().NotBeNull();
    }
}