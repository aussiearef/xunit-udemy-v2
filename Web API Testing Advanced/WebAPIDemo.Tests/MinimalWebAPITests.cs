using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
using WebAPIDemo.Data;

namespace WebAPIDemo.Tests;

public class CustomWebApplicationFactory<Program>  : WebApplicationFactory<Program> where Program : class
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.UseEnvironment("Testing");

        builder.ConfigureServices(services =>
        {
          // Remove the existing DbContext registration
            var dbContextDescriptors = services
                .Where(d => d.ServiceType == typeof(DbContextOptions<MyDbContext>) ||
                    d.ServiceType == typeof(MyDbContext))
                .ToList();

            foreach (var descriptor in dbContextDescriptors)
            {
                services.Remove(descriptor);
            }

            services.AddDbContext<MyDbContext>(options =>
                {
                    options.UseInMemoryDatabase($"TestDb"); // Use a fixed database name
                });  
        });     
        
        return base.CreateHost(builder);
    }
}

public class MinimalWebAPITests : IClassFixture<CustomWebApplicationFactory<Program>>, IDisposable
{
    private readonly HttpClient _client;
    private readonly CustomWebApplicationFactory<Program> _factory;

    public MinimalWebAPITests(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = _factory.CreateClient();
        InitializeDatabase();
    }

    private void InitializeDatabase()
    {
        using var scope = _factory.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<MyDbContext>();
        context.Database.EnsureCreated();
        context.Greetings.Add(new Greeting { Id = 2, Message = "Test Greeting" });
        context.SaveChanges();
    }

    [Fact]
    public async Task TestMe_GivenId_IdIsInResponse()
    {
        const int id = 2;
        var result = await _client.GetAsync($"/TestMe?id={id}");
        result.EnsureSuccessStatusCode();
        var content = await result.Content.ReadAsStringAsync();
        var json = JsonDocument.Parse(content);
        var idResult = json.RootElement.GetProperty("id").GetInt32();
        Assert.Equal(id, idResult);
    }

    public void Dispose()
    {
        using var scope = _factory.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<MyDbContext>();
        context.Database.EnsureDeleted();
    }
}
