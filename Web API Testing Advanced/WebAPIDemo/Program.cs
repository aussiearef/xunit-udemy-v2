using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.MapGet("/TestMe", async (int id, MyDbContext context)=>{
    
    var greeting = context.Greetings.FirstOrDefault(x => x.Id == id);
    await Task.Delay(1); // Simulate some async work
    return Results.Ok(greeting);
})
.WithName("TestMe");

await app.RunAsync();


public partial class Program { }