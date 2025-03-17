using System.Reflection.Metadata.Ecma335;

namespace Calculations.Test;

public class InsuranceTest
{
    [Fact]
    public void DiscountPercentage_GivenAgeOlderThan18_DiscountBetween5And20()
    {
        // Arrange
        var insurance = new Insurance();

        // Act
        var discount = insurance.DiscountPercentage(70);

        // Assert

        Assert.InRange(discount, 5, 20);
    }

    [Fact]
    public void DiscountPercentage_GivenAgeBelow25_DiscountIs5()
    {
        //Arrange
        var insurance = new Insurance();

        // Act
        var discount = insurance.DiscountPercentage(24);

        // Assert
        Assert.Equal(5, discount);
    }

    /*
     *  Add two or three unit tests for ages between 25 and 70
     */

    [Fact]
    public void DiscountPercentage_GivenAgeIsBelow18_ThrowsException()
    {
        // Arrange
        var insurance = new Insurance();

        // Act and Assert
        Assert.Throws<InvalidDataException>(()=> insurance.DiscountPercentage(5));
    }
}