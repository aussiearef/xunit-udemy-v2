namespace EcommerceTests;

[CollectionDefinition("InventoryTests")]
[Trait("Category", "Inventory")]
public class InventoryCollection { } // No shared fixture needed here

[CollectionDefinition("CheckoutTests")]
[Trait("Category", "Checkout")]
public class CheckoutCollection : ICollectionFixture<OrderServiceFixture> { }