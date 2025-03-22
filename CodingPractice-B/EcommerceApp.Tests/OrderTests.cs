namespace EcommerceTests;

[Collection("CheckoutTests")]
public class OrderTests
{
    private readonly OrderServiceFixture _fixture;

    public OrderTests(OrderServiceFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void ProcessOrder_Success()
    {
        var result = _fixture.Service.ProcessOrder(1, 2);
        Assert.Equal("Order placed for 2 of product 1", result);
    }
}