namespace EcommerceTests;

[Collection("InventoryTests")]
public class StockTests : IClassFixture<OrderServiceFixture>
{
    private readonly OrderServiceFixture _fixture;

    public StockTests(OrderServiceFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void CheckStock_InStock()
    {
        Assert.True(_fixture.Service.CheckStock(1, 3));
    }

    [Fact]
    public void CheckStock_OutOfStock()
    {
        Assert.False(_fixture.Service.CheckStock(2, 10));
    }
}