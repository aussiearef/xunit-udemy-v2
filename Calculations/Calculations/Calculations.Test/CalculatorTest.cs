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

    [Fact]
    public void GetFibonacci_DoesNotInclude0()
    {
        var calculator = new Calculator();
        var fibo = calculator.GetFibonacci(5);
        Assert.All(fibo, n=> Assert.NotEqual(0, n));
    }

    [Fact]
    public void GetFibonacci_DoesNotInclude4()
    {
        var calculator = new Calculator();
        var fibo = calculator.GetFibonacci(5);
        Assert.DoesNotContain(4, fibo);
    }

    [Fact]
    public void GetFibonacci_Includes5()
    {
        var calculator = new Calculator();
        var fibo = calculator.GetFibonacci(5);
        Assert.Contains(5, fibo);
    }

    [Fact]
    public void GetFibonacci_First5MembersAreCorrect()
    {
        var calculator = new Calculator();
        var fibo = calculator.GetFibonacci(5);
        var expectedSeries = new List<int>() { 1,1,2,3,5};

        Assert.Equal(expectedSeries, fibo);
    }

}