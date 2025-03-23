namespace Calculations;

public class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public decimal Add(decimal a, decimal b)
    {
        var sum = a + b;
        return Math.Round(sum, 2);
    }

    public IEnumerable<int> GetFibonacci(int length)
    {
        var first = 0;
        var second = 1;
        for (var i = 0; i < length; i++)
        {
            var next = first + second;

            first = second;
            second = next;

            yield return first;
        }

        // 1 1 3 5 8 13 ...
    }

    public bool IsOdd(int value)
    {
        return value % 2 != 0;
    }
}