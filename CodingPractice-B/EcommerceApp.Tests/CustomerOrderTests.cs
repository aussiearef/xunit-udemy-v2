namespace EcommerceTests;
using EcommerceApp;

[Collection("CheckoutTests")]
public class CustomerOrderTests
{
    private readonly OrderServiceFixture _fixture;
    private readonly CustomerService _customerService = new();

    public CustomerOrderTests(OrderServiceFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void ProcessOrder_WithCustomer()
    {
        var customer = _customerService.GetCustomerName(1);
        var result = _fixture.Service.ProcessOrder(1, 1);
        Assert.Equal("Order placed for 1 of product 1", result);
        Assert.Equal("Alice", customer);
    }
}