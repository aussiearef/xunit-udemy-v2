namespace Calculations.Test;

public class NamesTest
{
    [Fact]
    public void MakeFullName_GivenFirstNameLatName_ReturnsFullName()
    {
        var names = new Names();
        var fullName = names.MakeFullName("Aref", "Karimi");
        Assert.Equal("aref Karimi", fullName , ignoreCase: true);
    }

    [Fact]
    public void MakeFullName_GivenFirstNameLatName_MatchesRegex()
    {
        var names = new Names();
        var fullName = names.MakeFullName("Aref", "Karimi");
        Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+",fullName);
    }

    [Fact]
    public void MakeFullName_GivenFirstNameLatName_FirstNameExists()
    {
        var names = new Names();
        var fullName = names.MakeFullName("Aref", "Karimi");
        Assert.Contains("aref", fullName, StringComparison.InvariantCultureIgnoreCase);
    }

    [Fact]
    public void MakeFullName_GivenFirstNameLatName_BeginsWithFirstName()
    {
        var names = new Names();
        var fullName = names.MakeFullName("Aref", "Karimi");
        Assert.StartsWith("Aref" , fullName , StringComparison.InvariantCultureIgnoreCase);
    }
}