namespace Project_A;

public interface IProductRepository
{
    Task<Product> GetProductByIdAsync(int id);
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<bool> UpdateStockAsync(int productId, int quantity);
}

public class InMemoryProductRepository : IProductRepository
{
    private readonly List<Product> _products;

    public InMemoryProductRepository()
    {
        _products = new List<Product>
        {
            new() { Id = 1, Name = "Laptop", Price = 1000, Stock = 10 },
            new() { Id = 2, Name = "Phone", Price = 500, Stock = 20 }
        };
    }

    public Task<Product> GetProductByIdAsync(int id)
    {
        return Task.FromResult(_products.FirstOrDefault(p => p.Id == id));
    }

    public Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return Task.FromResult<IEnumerable<Product>>(_products);
    }

    public Task<bool> UpdateStockAsync(int productId, int quantity)
    {
        var product = _products.FirstOrDefault(p => p.Id == productId);
        if (product != null && product.Stock >= quantity)
        {
            product.Stock -= quantity;
            return Task.FromResult(true);
        }

        return Task.FromResult(false);
    }
}