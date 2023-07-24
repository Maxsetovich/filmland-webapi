using FilmLand.Service.Validators;

namespace FilmLand.UnitTest.ValidatorTests;

public class PasswordValidatorTest
{
    [Theory]
    [InlineData("AAaa@@11")]
    [InlineData("@!23#sfAB")]
    [InlineData("nsdj!#%^1236712tEFS")]
    [InlineData("#@ssVC432")]
    [InlineData("Aa1___)%")]
    [InlineData("Bb213dd.")]
    [InlineData("^sfCSS77,")]

    public void IsStrongPassword(string password)
    {
        var result = PasswordValidator.IsStrongPassword(password);
        Assert.True(result.IsValid);
    }
    [Theory]
    [InlineData("AAaa@@7")]
    [InlineData("BBbbb$#$qw")]
    [InlineData("BBB##$87218")]
    [InlineData("bbb##$87218")]
    [InlineData("BBB##$asdav")]
    [InlineData("BBBbfd87218")]
    [InlineData("AAA#@@123 ")]
    [InlineData("AAAAAAAAAAAA")]
    [InlineData("bbbbbbbbbbbbbb")]
    [InlineData("4444444444444")]
    [InlineData("@@@@@@@@@@@@@")]

    public void ShouldReturnWeakPassword(string password)
    {
        var result = PasswordValidator.IsStrongPassword(password);
        Assert.False(result.IsValid);
    }
}
