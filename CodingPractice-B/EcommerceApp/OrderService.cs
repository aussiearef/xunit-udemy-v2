namespace EcommerceApp;

public class OrderService
{
    private readonly Dictionary<int, int> _stock = new() { { 1, 10 }, { 2, 5 } }; // ProductId, Quantity

    public bool CheckStock(int productId, int quantity)
    {
        return _stock.TryGetValue(productId, out int available) && available >= quantity;
    }

    public string ProcessOrder(int productId, int quantity)
    {
        if (!CheckStock(productId, quantity))
            return "Out of stock";
        
        _stock[productId] -= quantity;
        return $"Order placed for {quantity} of product {productId}";
    }
}