var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/TestMe", async (int id)=>{
    await Task.Delay(1); // Simulate some async work
    return Results.Ok(new { id = id, message = "Hello World!" });
})
.WithName("TestMe");

await app.RunAsync();
