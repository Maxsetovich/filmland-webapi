using FilmLand.Service.Validators;

namespace FilmLand.UnitTest.ValidatorTests;

public class PhoneNumberValidatorTest
{
    [Theory]
    [InlineData("+998331213445")]
    [InlineData("+998903570818")]
    [InlineData("+998933644016")]
    [InlineData("+998971213745")]
    [InlineData("+998943693445")]

    public void ShouldReturnCorrect(string phone)
    {
        var result = PhoneNumberValidator.IsValid(phone);
        Assert.True(result);
    }

    [Theory]
    [InlineData("998901234567")]
    [InlineData("AABBa")]
    [InlineData("9989012345679")]
    [InlineData("+9989012T4567")]
    [InlineData("+99890124567")]
    [InlineData("+9989 1254567")]
    [InlineData("&998901254567")]
    [InlineData("-998901254567")]
    [InlineData("+99890 125 45 67")]

    public void ShouldReturnWrong(string phone)
    {
        var result = PhoneNumberValidator.IsValid(phone);
        Assert.False(result);
    }
}
