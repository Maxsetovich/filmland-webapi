using FilmLand.DataAccess.Interfaces.Countries;
using FilmLand.DataAccess.Utilities;
using FilmLand.Domain.Entities.Countries;
using FilmLand.Domain.Exceptions.Countries;
using FilmLand.Service.Common.Helpers;
using FilmLand.Service.Dtos.Countries;
using FilmLand.Service.Interfaces.Common;
using FilmLand.Service.Interfaces.Countries;

namespace FilmLand.Service.Services.Countries;

public class CountryService : ICountryService
{
    private readonly ICountryRepository _repository;
    private readonly IPaginator _paginator;

    public CountryService(ICountryRepository countryRepository,
        IPaginator paginator)
    {
        this._repository = countryRepository;
        this._paginator = paginator;
    }
    public async Task<long> CountAsync() => await _repository.CountAsync();

    public async Task<bool> CreateAsync(CountryCreateDto dto)
    {
        Country country = new Country()
        {
            Name = dto.Name,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime()
        };
        var result = await _repository.CreateAsync(country);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(long countryId)
    {
        var country = await _repository.GetByIdAsync(countryId);
        if (country is null) throw new CountryNotFoundException();

        var dbResult = await _repository.DeleteAsync(countryId);
        return dbResult > 0;
    }

    public async Task<IList<Country>> GetAllAsync(PaginationParams @params)
    {
        var countries = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);
        return countries;
    }

    public async Task<Country> GetByIdAsync(long countryId)
    {
        var country = await _repository.GetByIdAsync(countryId);
        if (country is null) throw new CountryNotFoundException();
        else return country;
    }

    public async Task<bool> UpdateAsync(long countryId, CountryUpdateDto dto)
    {
        var country = await _repository.GetByIdAsync(countryId);
        if (country is null) throw new CountryNotFoundException();

        // parse new items to country
        country.Name = dto.Name;

        country.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _repository.UpdateAsync(countryId, country);
        return dbResult > 0;
    }
}
