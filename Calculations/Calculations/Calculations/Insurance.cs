using System.Runtime.Serialization;

namespace Calculations;

public class Insurance
{
    public int DiscountPercentage(int age)
    {
        switch (age)
        {
            case >= 65: return 5;
            case >= 45: return 10;
            case >= 25: return 20;
            case >= 18: return 5;
            default: throw new InvalidDataException();
        }
    }
}