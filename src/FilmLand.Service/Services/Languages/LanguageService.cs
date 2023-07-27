using FilmLand.DataAccess.Interfaces.Languages;
using FilmLand.DataAccess.Utilities;
using FilmLand.Domain.Entities.Languages;
using FilmLand.Domain.Exceptions.Languages;
using FilmLand.Service.Common.Helpers;
using FilmLand.Service.Dtos.Languages;
using FilmLand.Service.Interfaces.Common;
using FilmLand.Service.Interfaces.Languages;

namespace FilmLand.Service.Services.Languages;

public class LanguageService : ILanguageService
{
    private readonly ILanguageRepository _repository;
    private readonly IPaginator _paginator;

    public LanguageService(ILanguageRepository languageRepository,
        IPaginator paginator)
    {
        this._repository = languageRepository;
        this._paginator = paginator;
    }

    public async Task<long> CountAsync() => await _repository.CountAsync();

    public async Task<bool> CreateAsync(LanguageCreateDto dto)
    {
        Language language = new Language()
        {
            Name = dto.Name,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime()
        };
        var result = await _repository.CreateAsync(language);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(long languageId)
    {
        var language = await _repository.GetByIdAsync(languageId);
        if (language is null) throw new LanguageNotFoundException();

        var dbResult = await _repository.DeleteAsync(languageId);
        return dbResult > 0;
    }

    public async Task<IList<Language>> GetAllAsync(PaginationParams @params)
    {
        var languages = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);
        return languages;
    }

    public async Task<Language> GetByIdAsync(long languageId)
    {
        var language = await _repository.GetByIdAsync(languageId);
        if (language is null) throw new LanguageNotFoundException();
        else return language;
    }

    public async Task<bool> UpdateAsync(long languageId, LanguageUpdateDto dto)
    {
        var language = await _repository.GetByIdAsync(languageId);
        if (language is null) throw new LanguageNotFoundException();

        // parse new items to language
        language.Name = dto.Name;

        language.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _repository.UpdateAsync(languageId, language);
        return dbResult > 0;
    }
}
