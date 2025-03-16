namespace Project_A;

public interface IOrderService
{
    Task<Order?> CreateOrderAsync(int customerId, List<int> productIds);
    Task<decimal> CalculateTotalAmountAsync(List<int> productIds);
}

public class OrderService : IOrderService
{
    private readonly IProductRepository _productRepository;

    public OrderService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Order?> CreateOrderAsync(int customerId, List<int> productIds)
    {
        var products = new List<Product>();
        decimal totalAmount = 0;

        foreach (var productId in productIds)
        {
            var product = await _productRepository.GetProductByIdAsync(productId);
            if (product.Stock > 0)
            {
                products.Add(product);
                totalAmount += product.Price;
                await _productRepository.UpdateStockAsync(productId, 1);
            }
        }
        
        return products.Any() ?

         new Order
        {
            Customer = new Customer { Id = customerId, Name = "John Doe", Email = "john@example.com" },
            Products = products,
            TotalAmount = totalAmount,
            OrderDate = DateTime.Now
        } : null;
    }

    public async Task<decimal> CalculateTotalAmountAsync(List<int> productIds)
    {
        decimal totalAmount = 0;
        foreach (var productId in productIds)
        {
            var product = await _productRepository.GetProductByIdAsync(productId);
            if (product != null) totalAmount += product.Price;
        }

        return totalAmount;
    }
}