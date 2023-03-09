using FluentAssertions;
using Previred;

namespace PreviredTesting;

public class MainTest
{
    [Test]
    public async Task MainEnter()
    {
        var previredApi = new PreviredApi(Credentials.Instance.TokenApi);
        var imposition = await previredApi.GetImposition(Credentials.Instance.PathFileTest);
        imposition.Should().NotBeNull();
    }
}