using FilmLand.DataAccess.Interfaces.Companies;
using FilmLand.DataAccess.Utilities;
using FilmLand.Domain.Entities.Companies;
using FilmLand.Domain.Exceptions.Companies;
using FilmLand.Domain.Exceptions.Files;
using FilmLand.Service.Common.Helpers;
using FilmLand.Service.Dtos.Companies;
using FilmLand.Service.Interfaces.Common;
using FilmLand.Service.Interfaces.Companies;
using System.IO;

namespace FilmLand.Service.Services.Companies;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _repository;
    private readonly IFileService _fileService;
    private readonly IPaginator _paginator;

    public CompanyService(ICompanyRepository companyRepository,
        IFileService fileService,
        IPaginator paginator)
    {
        this._repository = companyRepository;
        this._fileService = fileService;
        this._paginator = paginator;
    }

    public async Task<long> CountAsync() => await _repository.CountAsync();

    public async Task<bool> CreateAsync(CompanyCreateDto dto)
    {
        string imagepath = await _fileService.UploadImageAsync(dto.Image);
        Company company = new Company()
        {
            ImagePath = imagepath,
            Name = dto.Name,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime()
        };
        var result = await _repository.CreateAsync(company);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(long companyId)
    {
        var company = await _repository.GetByIdAsync(companyId);
        if(company is null) throw new CompanyNotFoundException();

        var result = await _fileService.DeleteImageAsync(company.ImagePath);
        if (result == false) throw new ImageNotFoundException();

        var dbResult = await _repository.DeleteAsync(companyId);
        return dbResult > 0;
    }

    public async Task<IList<Company>> GetAllAsync(PaginationParams @params)
    {
        var companies = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);
        return companies;
    }

    public async Task<Company> GetByIdAsync(long companyId)
    {
        var company = await _repository.GetByIdAsync(companyId);
        if (company is null) throw new CompanyNotFoundException();
        else return company;
    }

    public async Task<bool> UpdateAsync(long companyId, CompanyUpdateDto dto)
    {
        var company = await _repository.GetByIdAsync(companyId);
        if (company is null) throw new CompanyNotFoundException();

        // parse new items to company
        company.Name = dto.Name;

        if (dto.Image is not null)
        {
            // delete old image
            var deleteResult = await _fileService.DeleteImageAsync(company.ImagePath);
            if (deleteResult is false) throw new ImageNotFoundException();

            // upload new image
            string newImagePath = await _fileService.UploadImageAsync(dto.Image);

            // parse new path to category
            company.ImagePath = newImagePath;
        }
        // else company old image is have to save
        company.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _repository.UpdateAsync(companyId, company);
        return dbResult > 0;
    }
}
