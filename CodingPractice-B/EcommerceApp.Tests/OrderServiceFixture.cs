namespace EcommerceTests;

using EcommerceApp;
public class OrderServiceFixture : IDisposable
{
    public OrderService Service { get; } = new OrderService();
    public OrderServiceFixture() => Console.WriteLine("OrderServiceFixture created");
    public void Dispose() => Console.WriteLine("OrderServiceFixture disposed");
}