namespace EcommerceTests;

using Xunit.Internal;
using Xunit.Sdk;
using Xunit.v3;
public class CategoryOrderer : ITestCollectionOrderer
{
    public IReadOnlyCollection<TTestCollection> OrderTestCollections<TTestCollection>(IReadOnlyCollection<TTestCollection> testCollections)
        where TTestCollection : ITestCollection
    {
        return testCollections
            .OrderBy(x => x.Traits.TryGetValue("Category", out var values) && values.Contains("Checkout") ? 0 : 1)
            .ToList()
            .AsReadOnly();
    }
}