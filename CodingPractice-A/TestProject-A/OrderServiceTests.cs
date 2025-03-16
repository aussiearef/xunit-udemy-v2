using Project_A;
using Xunit;

namespace TestProject_A;

public class OrderServiceTests
{
    private readonly IOrderService _orderService;
    private readonly IProductRepository _productRepository;

    public OrderServiceTests()
    {
        _productRepository = new InMemoryProductRepository(); // Use in-memory repository
        _orderService = new OrderService(_productRepository);
    }

    [Fact]
    public async Task CreateOrderAsync_ValidProducts_ReturnsOrderWithTotalAmount()
    {
        // Arrange
        var productIds = new List<int> { 1, 2 };

        // Act
        var order = await _orderService.CreateOrderAsync(1, productIds);

        // Assert

        // Check order is not null
        // Check order's total amount is 1500
        // Check order's number of products is 2
        // Check _productRepository.GetProductByIdAsync(1).Stock returns 9  
        // Check _productRepository.GetProductByIdAsync(2)).Stock returns 19
    }

    [Fact]
    public async Task CreateOrderAsync_InsufficientStock_ThrowsException()
    {
        // Arrange
        var productIds = new List<int> { 1 }; // Request more than available stock
        var product = await _productRepository.GetProductByIdAsync(1);


        // Act

        product.Stock = 10;
        var orderA = await _orderService.CreateOrderAsync(1, productIds);

        product.Stock = 0;
        var orderB = await _orderService.CreateOrderAsync(1, productIds);


        // Assert
        // Check OrderA is not null 
        // Check OrderB is null  -- explain why it's null?!
    }

    [Fact]
    public async Task CalculateTotalAmountAsync_ValidProducts_ReturnsCorrectAmount()
    {
        // Arrange
        var productIds = new List<int> { 1, 2 };

        // Act
        var totalAmount = await _orderService.CalculateTotalAmountAsync(productIds);

        // Assert
        // Check total amount is 1500;
    }
}