namespace Calculations.Test;

[Collection("Insurance")]
public class InsuranceDetailsTest (InsuranceFixture insuranceFixture)
{
    private readonly InsuranceFixture _insuranceFixture = insuranceFixture;

    [Fact]
    public void Insurance_InterestRate_Return10()
    {
        //var insurance = new Insurance();

        var insurance = _insuranceFixture.Insurance;
        Assert.Equal(10, insurance.InterestRate);
    }
}