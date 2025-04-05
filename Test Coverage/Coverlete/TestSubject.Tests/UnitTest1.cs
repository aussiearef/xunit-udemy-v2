namespace TestSubject.Tests;
using Xunit;
using TestSubject;
using System;
public class UnitTest1
{
    [Fact]
    public void IsNumberEven_Given2_ReturnsTrue()
    {
        // Arrange
        var rng = new  RandomNumberGenerator();
        int number = 2;

        // Act
        bool result = rng.IsNumberEven(number);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void GenerateNumber_GivenMinAndMax_ReturnValueIsSmallerThanMax()
    {
        // Arrange
        var rng = new RandomNumberGenerator();
        const int min =1;
        const int max=10;

        // Act
        var randomNumber = rng.GenerateNumber(min, max);

        Console.WriteLine($"Generated number: {randomNumber}");
        bool result = randomNumber < max;

        // Assert
        Assert.True(result);
    }
}
