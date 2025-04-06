using Microsoft.AspNetCore.Mvc.Testing;
using System.Text.Json;

namespace WebAPIDemo.Tests;

public class MinimalWebAPITests : IClassFixture<WebApplicationFactory<Program>> 
{

    private readonly HttpClient _client;
    public MinimalWebAPITests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task TestMe_GivenId_IdIsInResponse()
    {
        const int id = 2;

        var result = await _client.GetAsync($"/TestMe?id={id}", TestContext.Current.CancellationToken);

        result.EnsureSuccessStatusCode();

        var content = await result.Content.ReadAsStringAsync(TestContext.Current.CancellationToken);

        var json = JsonDocument.Parse(content);

        var idResult = json.RootElement.GetProperty("id").GetInt32();

        Assert.Equal(id, idResult);
    }
}
