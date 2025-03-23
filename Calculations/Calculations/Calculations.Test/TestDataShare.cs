namespace Calculations.Test;

public static class TestDataShare
{
    public static IEnumerable<object[]> ValuesForAddMethod
    {
        get
        {
            yield return new object[] { 1, 2, 3 };
            yield return new object[] { -3, 2, -1 };
        }
    }
}