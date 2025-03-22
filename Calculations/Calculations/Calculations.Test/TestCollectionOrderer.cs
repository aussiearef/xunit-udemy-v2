using Xunit.Internal;
using Xunit.Sdk;
using Xunit.v3;

namespace Calculations.Test;

public class TestCollectionOrderer : ITestCollectionOrderer
{
    public IReadOnlyCollection<TTestCollection> OrderTestCollections<TTestCollection>(
        IReadOnlyCollection<TTestCollection> testCollections) where TTestCollection : ITestCollection
    {
         // return testCollections.OrderBy(x => x.TestCollectionDisplayName).CastOrToReadOnlyCollection();

         return testCollections.OrderBy(x =>
         {
             Console.WriteLine("Test Ordering...");
             x.Traits.TryGetValue("Category", out var categories);
             if (categories != null && categories.Any())
             {
                 return categories.FirstOrDefault() ?? "";
             }
             else
                 return x.TestCollectionDisplayName;

         }).CastOrToReadOnlyCollection();
    }
}