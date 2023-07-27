using FilmLand.DataAccess.Utilities;
using FilmLand.Domain.Entities.Languages;
using FilmLand.Service.Dtos.Languages;

namespace FilmLand.Service.Interfaces.Languages;

public interface ILanguageService
{
    public Task<bool> CreateAsync(LanguageCreateDto dto);

    public Task<bool> DeleteAsync(long languageId);

    public Task<long> CountAsync();

    public Task<IList<Language>> GetAllAsync(PaginationParams @params);

    public Task<Language> GetByIdAsync(long languageId);

    public Task<bool> UpdateAsync(long languageId, LanguageUpdateDto dto);
}
