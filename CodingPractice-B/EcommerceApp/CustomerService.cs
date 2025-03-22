
namespace EcommerceApp;
public class CustomerService
{
    private readonly Dictionary<int, string> _customers = new() { { 1, "Alice" }, { 2, "Bob" } }; // CustomerId, Name

    public string GetCustomerName(int customerId)
    {
        return _customers.TryGetValue(customerId, out string name) ? name : "Unknown";
    }
}