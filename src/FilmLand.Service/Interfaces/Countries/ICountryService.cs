using FilmLand.DataAccess.Utilities;
using FilmLand.Domain.Entities.Countries;
using FilmLand.Service.Dtos.Countries;

namespace FilmLand.Service.Interfaces.Countries;

public interface ICountryService
{
    public Task<bool> CreateAsync(CountryCreateDto dto);

    public Task<bool> DeleteAsync(long countryId);

    public Task<long> CountAsync();

    public Task<IList<Country>> GetAllAsync(PaginationParams @params);

    public Task<Country> GetByIdAsync(long countryId);

    public Task<bool> UpdateAsync(long countryId, CountryUpdateDto dto);
}
