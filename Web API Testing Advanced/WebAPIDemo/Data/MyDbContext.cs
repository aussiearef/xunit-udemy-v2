namespace WebAPIDemo.Data;
using Microsoft.EntityFrameworkCore;
public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

    public virtual DbSet<Greeting> Greetings { get; set; }
}


