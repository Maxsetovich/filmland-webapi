using FilmLand.Service.Dtos.Companies;
using FilmLand.Service.Validators.Dtos.Company;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace FilmLand.UnitTest.ValidatorTests.Companies;

public class CompanyCreateValidatorTest
{
    [Theory]
    [InlineData(3.1)]
    [InlineData(3.01)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(7)]

    public void ShouldReturnWrongImageFileSize(double imageSizeMB)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("widfjadas qiwdxoplsnd akiwdjoqiwd akwdnfajksfoq");
        long imageSizeInBytes = (long)(imageSizeMB * 1024 * 1024);
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, imageSizeInBytes, "data", "file.png");
        CompanyCreateDto companyCreateDto = new CompanyCreateDto()
        {
            Name = "Universal Company",
            Image = imageFile
        };
        var validator = new CompanyCreateValidator();
        var result = validator.Validate(companyCreateDto);
        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData(2.95)]
    [InlineData(3)]
    [InlineData(2.5)]
    [InlineData(1)]
    [InlineData(0.5)]
    [InlineData(0.75)]

    public void ShouldReturnCorrectImageFileSize(double imageSizeMB)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("widfjadas qiwdxoplsnd akiwdjoqiwd akwdnfajksfoq");
        long imageSizeInBytes = (long)(imageSizeMB * 1024 * 1024);
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, imageSizeInBytes, "data", "file.png");
        CompanyCreateDto companyCreateDto = new CompanyCreateDto()
        {
            Name = "Universal Company",
            Image = imageFile
        };
        var validator = new CompanyCreateValidator();
        var result = validator.Validate(companyCreateDto);
        Assert.True(result.IsValid);
    }


    [Theory]
    [InlineData("file.png")]
    [InlineData("file.jpg")]
    [InlineData("file.jpeg")]
    [InlineData("file.svg")]
    [InlineData("file.bmp")]

    public void ShouldReturnValidImageFileExtension(string imagname)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("widfjadas qiwdxoplsnd akiwdjoqiwd akwdnfajksfoq dsvwiuefhwhdq mdvn");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", imagname);
        CompanyCreateDto companyCreateDto = new CompanyCreateDto()
        {
            Name = "Universal Company",
            Image = imageFile
        };
        var validator = new CompanyCreateValidator();
        var result = validator.Validate(companyCreateDto);
        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData("file.zip")]
    [InlineData("file.mp3")]
    [InlineData("file.html")]
    [InlineData("file.gif")]
    [InlineData("file.txt")]
    [InlineData("file.HEIC")]
    [InlineData("file.mp4")]
    [InlineData("file.avi")]
    [InlineData("file.mvk")]
    [InlineData("file.vaw")]
    [InlineData("file.webp")]
    [InlineData("file.pdf")]
    [InlineData("file.doc")]
    [InlineData("file.docx")]
    [InlineData("file.xls")]
    [InlineData("file.dll")]
    [InlineData("file.exe")]

    public void ShouldReturnWrongImageFileExtension(string imagname)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("nxcqpwkf apowdknc qwudwdj[pofefj vfdmnbriowjowep cmx zl;akd0qwi");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", imagname);

        CompanyCreateDto companyCreateDto = new CompanyCreateDto()
        {
            Name = "Universal Company",
            Image = imageFile
        };
        var validator = new CompanyCreateValidator();
        var result = validator.Validate(companyCreateDto);
        Assert.False(result.IsValid);
    }

    [Fact]
    public void ShouldReturnValidValidation()
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("widfjadas qiwdxoplsnd akiwdjoqiwd akwdnfajksfoq");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.png");
        CompanyCreateDto companyCreateDto = new CompanyCreateDto()
        {
            Name = "Universal Company",
            Image = imageFile
        };
        var validator = new CompanyCreateValidator();
        var result = validator.Validate(companyCreateDto);
        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData("AA")]
    [InlineData("A")]
    [InlineData("electronic products, we sell an electronic products to our clients, we sell an electronic products to our clients")]

    public void ShouldReturnInValidValidation(string name)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("widfjadas qiwdxoplsnd akiwdjoqiwd akwdnfajksfoq");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.jng");
        CompanyCreateDto companyCreateDto = new CompanyCreateDto()
        {
            Name = name,
            Image = imageFile
        };
        var validator = new CompanyCreateValidator();
        var result = validator.Validate(companyCreateDto);
        Assert.False(result.IsValid);
    }
}
