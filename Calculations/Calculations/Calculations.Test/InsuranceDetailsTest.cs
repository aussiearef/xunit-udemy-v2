namespace Calculations.Test;

[Collection("Insurance")]
public class InsuranceDetailsTest(InsuranceCollectionFixture insuranceCollectionFixture)
{
    private readonly InsuranceCollectionFixture _insuranceCollectionFixture = insuranceCollectionFixture;

    [Fact]
    public void Insurance_InterestRate()
    {
        //var insurance = new Insurance();
        var insurance = _insuranceCollectionFixture.Insurance;
        Assert.Equal(10, insurance.InterestRate);
    }
}