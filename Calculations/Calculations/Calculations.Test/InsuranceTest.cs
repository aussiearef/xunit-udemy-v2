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

    [Fact]
    public void Customer_YearsLessThan5_ReturnsCustomer()
    {
        var customer = CustomerFactory.GetInstance(3, 20);

        //Assert.IsType(typeof(Customer), customer);

        Assert.IsType<Customer>(customer);

        // discount = 15%
    }

    [Fact]
    public void Customer_YearsMoreThan5_ReturnsLoyalCustomer()
    {
        var customer = CustomerFactory.GetInstance(10, 20);

        //Assert.IsType(typeof(Customer), customer);

        Assert.IsType<Customer>(customer, false);
        
        // Assert.IsNotType<LoyalCustomer>(customer);

        // discount = 15%
    }

    // Add tests to check if the discount for a loyal customer is calculated correctly.

}