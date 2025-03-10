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
}