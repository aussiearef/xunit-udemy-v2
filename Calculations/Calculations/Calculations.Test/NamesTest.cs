namespace Calculations.Test;
using FluentAssertions;

[Trait("Category","Names")]
[Collection("Names")]
public class NamesTest
{
    [Fact]
    public void MakeFullName_GivenFirstNameLastName_ResultMatchesFluentChecks()
    {
        var names = new Names();
        var fullName = names.MakeFullName("Aref", "Karimi");

        fullName.Should().NotBeNullOrEmpty().And.ContainEquivalentOf("Aref", LessThan.Times(5)).And.MatchRegex("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+");
    }


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

    [Fact]
    public void MakeFullName_GivenMethodNotCalled_NickNameMustBeNull()
    {
        var names = new Names();
        Assert.Null(names.NickName);
        var fullName = names.MakeFullName("Aref", "Karimi");
        Assert.NotNull(names.NickName);

        // Assert to make sure that the format of Nickname is correct.

        
        Assert.True(!String.IsNullOrEmpty(names.NickName));
        

    }
}