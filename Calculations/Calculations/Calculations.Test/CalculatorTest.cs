namespace Calculations.Test;

public class CalculatorFixture
{
    public Calculator Calc => new();
}

public class CalculatorTest(ITestOutputHelper testOutputHelper, CalculatorFixture calculatorFixture)
    : IClassFixture<CalculatorFixture>
{
    private readonly CalculatorFixture _calculatorFixture = calculatorFixture;
    private readonly ITestOutputHelper _testOutputHelper = testOutputHelper;

    [Fact]
    [Trait("Category", "Calculator")]
    [Trait("Owner", "Aref")]
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


    [Theory]
    //[InlineData(1,2,3)]
    //[InlineData(-3, 2, -1)]
    //[MemberData(nameof(TestDataShare.ValuesForAddMethod), MemberType = typeof(TestDataShare))]
    [AddData]
    public void Add_GivenTwoNumbers_ReturnsSum(int a, int b, int expected)
    {
        var calc = new Calculator();
        var result = calc.Add(a, b);
        Assert.Equal(expected, result);
    }


    [Theory]
    //[MemberData(nameof(TestDataShare.ValuesForAddMethod), MemberType = typeof(TestDataShare))]
    [AddData]
    public void Add_GivenTwoDecimalNumbers_ReturnsSum(decimal a, decimal b, decimal expected)
    {
        var calc = new Calculator();
        var result = calc.Add(a, b);
        Assert.Equal(expected, result);
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