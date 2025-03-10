namespace Calculations.Test;

public class CalculatorTest
{
    [Fact]
    public void Add_Given1and2_Returns3()
    {
        // Arrange
        var calculator = new Calculator();

        // Act
        var sum = calculator.Add(1, 2);

        // Assert
        Assert.Equal(3 , sum);
    }

    [Fact]
    public void Add_GivenTwoDecimalValues_ReturnsSumWithTwoPlaces()
    {
        // Arrange
        var calculator = new Calculator();

        // Act
        var sum = calculator.Add(1.5m, 1.28m);

        // Assert
        Assert.Equal(2.8m , sum , 1);
    }
}