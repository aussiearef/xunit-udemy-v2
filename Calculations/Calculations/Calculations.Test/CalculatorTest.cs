using System.Diagnostics.CodeAnalysis;
using Xunit.Sdk;

namespace Calculations.Test;


public class CalculatorFixture
{
    public Calculator Calc => new Calculator();
}

public class CalculatorTest (ITestOutputHelper testOutputHelper , CalculatorFixture calculatorFixture) : IClassFixture<CalculatorFixture>
{
    private readonly ITestOutputHelper _testOutputHelper = testOutputHelper;
    private readonly CalculatorFixture _calculatorFixture = calculatorFixture;

    [Fact]
    [Trait("Category", "Calculator")]
    [Trait("Owner","Aref")]
    public void Add_Given1and2_Returns3()
    {

        _testOutputHelper.WriteLine("Test Executed");
        // Arrange
        var calculator = new Calculator();

        // Act
        var sum = calculator.Add(1, 2);

        // Assert
        Assert.Equal(3, sum);
    }

    [Fact]
    [Trait("Category", "Calculator")]
    [Trait("Owner", "Aref")]
    public void Add_GivenTwoDecimalValues_ReturnsSumWithTwoPlaces()
    {
        // Arrange
        var calculator = new Calculator();

        // Act
        var sum = calculator.Add(1.5m, 1.28m);

        // Assert
        Assert.Equal(2.8m, sum, 1);
    }


    [Fact]
    [Trait("Category", "Fibo")]
    public void GetFibonacci_DoesNotInclude0()
    {
        //var calculator = new Calculator();
        var calculator = _calculatorFixture.Calc;
        var fibo = calculator.GetFibonacci(5);
        Assert.All(fibo, n => Assert.NotEqual(0, n));
    }

    [Fact]
    [Trait("Category", "Fibo")]
    public void GetFibonacci_DoesNotInclude4()
    {
        //var calculator = new Calculator();
        var calculator = _calculatorFixture.Calc;
        var fibo = calculator.GetFibonacci(5);
        Assert.DoesNotContain(4, fibo);
    }

    [Fact]
    [Trait("Category", "Fibo")]
    public void GetFibonacci_Includes5()
    {
       //var calculator = new Calculator();
       var calculator = _calculatorFixture.Calc;
        var fibo = calculator.GetFibonacci(5);
        Assert.Contains(5, fibo);
    }

    [Fact]
    [Trait("Category", "Fibo")]
    public void GetFibonacci_First5MembersAreCorrect()
    {
        //var calculator = new Calculator();
        var calculator = _calculatorFixture.Calc;
        var fibo = calculator.GetFibonacci(5);
        var expectedSeries = new List<int> { 1, 1, 2, 3, 5 };

        Assert.Equal(expectedSeries, fibo);
    }
}